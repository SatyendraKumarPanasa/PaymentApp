using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
   public class GetRegisteredUserData : IExecuteDataRequestAsync<UserSearchRequest, List<Users>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetRegisteredUserData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<List<Users>> ExecuteAsync(UserSearchRequest userSearchRequest)
        {
            var regUserData = await _PaymentAppDbContextQuery.Users.
                Where(x =>
                (string.IsNullOrEmpty(userSearchRequest.FirstName) ? x.FirstName == x.FirstName : x.FirstName == userSearchRequest.FirstName)
                &&
                (string.IsNullOrEmpty(userSearchRequest.LastName) ? x.LastName == x.LastName : x.LastName == userSearchRequest.LastName)
                &&
                (string.IsNullOrEmpty(userSearchRequest.Email) ? x.Email == x.Email : x.Email == userSearchRequest.Email)
                &&
                 (userSearchRequest.RoleId == 0 ? x.RoleId == x.RoleId : x.RoleId == userSearchRequest.RoleId)

                 ).ToListAsync();

            var userEnt = _mapper.Map<List<Users>>(regUserData);

            return userEnt;


        }
    }
}
