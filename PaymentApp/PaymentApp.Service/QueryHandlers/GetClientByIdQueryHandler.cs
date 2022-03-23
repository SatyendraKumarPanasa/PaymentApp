using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetClientByIdQueryHandler : IHandleQueryAsync<int, Clients>
    {
        private readonly IExecuteDataRequestAsync<int, Clients> _getClient;

        public GetClientByIdQueryHandler(IExecuteDataRequestAsync<int, Clients> getClient)
        {
            _getClient = getClient;
        }
        public async Task<Clients> ExecuteAsync(int id)
        {
            var client = await _getClient.ExecuteAsync(id);

            return client;
        }
    }
}
