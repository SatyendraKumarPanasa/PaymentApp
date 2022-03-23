using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetAllVendorsData : IExecuteDataRequestAsync<List<Vendors>>
     {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllVendorsData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<Vendors>> ExecuteAsync()
        {
            List<Vendors> vendors = new List<Vendors>();
            var ret = await _PaymentAppDbContextQuery.Vendors.ToListAsync();

            vendors = _mapper.Map<List<Vendors>>(ret);

            return vendors;
        }
    }
}
