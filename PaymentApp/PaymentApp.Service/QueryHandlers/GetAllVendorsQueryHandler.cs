using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetAllVendorsQueryHandler : IHandleQueryAsync<List<Vendors>>
    {

        private readonly IExecuteDataRequestAsync<List<Vendors>> _getAllVendors;

        public GetAllVendorsQueryHandler(IExecuteDataRequestAsync<List<Vendors>> getAllVendors)
        {
            _getAllVendors = getAllVendors;
        }

        public async Task<List<Vendors>> ExecuteAsync()
        {
            return await _getAllVendors.ExecuteAsync();
        }
    }
}
