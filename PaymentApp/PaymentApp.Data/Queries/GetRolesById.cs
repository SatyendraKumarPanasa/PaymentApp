using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetRolesById : IExecuteDataRequestAsync<int, Roles>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetRolesById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<Roles> ExecuteAsync(int id)
        {
            var roles = await _PaymentAppDbContextQuery.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<Roles>(roles);
        }
    }
}
