using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetLocationsByIdQueryHandler : IHandleQueryAsync<int, List<Location>>
    {
        private readonly IExecuteDataRequestAsync<int, List<Location>> _getLocations;

        public GetLocationsByIdQueryHandler(IExecuteDataRequestAsync<int, List<Location>> getLocations)
        {
            _getLocations = getLocations;
        }
        public async Task<List<Location>> ExecuteAsync(int id)
        {
            var locations = await _getLocations.ExecuteAsync(id);

            return locations;
        }
    }
}
