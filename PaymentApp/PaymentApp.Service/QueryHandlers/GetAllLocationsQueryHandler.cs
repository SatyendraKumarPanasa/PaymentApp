using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
   public class GetAllLocationsQueryHandler : IHandleQueryAsync<List<Location>>
    {
        private readonly IExecuteDataRequestAsync<List<Location>> _getAllLocations;

        public GetAllLocationsQueryHandler(IExecuteDataRequestAsync<List<Location>> getAllLocations)
        {
            _getAllLocations = getAllLocations;
        }

        public async Task<List<Location>> ExecuteAsync()
        {
            return await _getAllLocations.ExecuteAsync();
        }
    }
}
