using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetAllRolesData : IExecuteDataRequestAsync<List<Roles>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllRolesData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<List<Roles>> ExecuteAsync()
        {
            List<Roles> roles = new List<Roles>();
            var ret = await _PaymentAppDbContextQuery.Roles.ToListAsync();

            roles = _mapper.Map<List<Roles>>(ret);

            return roles;
        }
    }
}
