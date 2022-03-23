using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetVendorByIdQueryHandler : IHandleQueryAsync<int, Vendors>
    {
        private readonly IExecuteDataRequestAsync<int, Vendors> _getVendor;

        public GetVendorByIdQueryHandler(IExecuteDataRequestAsync<int, Vendors> getVendor)
        {
            _getVendor = getVendor;
        }
        public async Task<Vendors> ExecuteAsync(int id)
        {
            return await _getVendor.ExecuteAsync(id);

        }
    }
}
