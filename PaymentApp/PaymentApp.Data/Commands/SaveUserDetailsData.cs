using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
    public class SaveUserDetailsData : IExecuteDataRequestAsync<Users, Response<Users>>
    {

        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly IMapper _mapper;
        private readonly Response<Users> _response;

        public SaveUserDetailsData(PaymentAppDbContextCommand PaymentAppDbContextCommand, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _mapper = mapper;
            _response = new Response<Users>();
        }
        public async Task<Response<Users>> ExecuteAsync(Users users)
        {
           
                var duplicateEmail = await _PaymentAppDbContextCommand.Users
                                                  .FirstOrDefaultAsync(x => (x.Email == users.Email && x.Password == users.Password));

            if (duplicateEmail != null)
            {
                _response.Result = _mapper.Map<Users>(duplicateEmail); ;

                _response.AddError("Es201", "Email is already Registered");

                return _response;
            }
            else
            {
                var userData = _mapper.Map<UsersEntity>(users);
                userData.StartDate = DateTime.Now;
                userData.Status = true;
                _PaymentAppDbContextCommand.Users.Add(userData);

                await _PaymentAppDbContextCommand.SaveChangesAsync();

                _response.Result = _mapper.Map<Users>(userData);
            }
                return _response;
           
          
        }
    }
}
