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
    public class GetVendorById : IExecuteDataRequestAsync<int, Vendors>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetVendorById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<Vendors> ExecuteAsync(int id)
        {
            var vendor = await _PaymentAppDbContextQuery.Vendors.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<Vendors>(vendor);
        }
    }
}
