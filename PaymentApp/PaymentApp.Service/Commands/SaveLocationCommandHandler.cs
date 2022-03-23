using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
    class SaveLocationCommandHandler : IHandleCommandAsync<Location, Response<Location>>
    {
        private readonly IExecuteDataRequestAsync<Location, Response<Location>> _saveLocation;

        public SaveLocationCommandHandler(IExecuteDataRequestAsync<Location, Response<Location>> saveEmployee)
        {
            _saveLocation = saveEmployee;
        }
        public async Task<Response<Location>> ExecuteAsync(Location location)
        {
            return await _saveLocation.ExecuteAsync(location);
        }
    }
}