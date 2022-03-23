using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
    public class LoginDetailsData : IExecuteDataRequestAsync<LoginViewModel, LoginViewModel>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextCommand;
        private readonly IMapper _mapper;
        //private readonly Response<EmployeeRegister> _response;

        public LoginDetailsData(PaymentAppDbContextQuery PaymentAppDbContextCommand, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _mapper = mapper;
            //  _response = new Response<bool>();
        }

        public async Task<LoginViewModel> ExecuteAsync(LoginViewModel loginViewModel)
        {
            try
            {
                var emailRegistered = await _PaymentAppDbContextCommand.Users.
                    FirstOrDefaultAsync(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);


                if (emailRegistered != null)
                {
                    return loginViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                return null;

            }



        }
    }
}
