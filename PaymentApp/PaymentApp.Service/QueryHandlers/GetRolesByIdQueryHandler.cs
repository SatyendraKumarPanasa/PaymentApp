using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetRolesByIdQueryHandler : IHandleQueryAsync<int, Roles>
    {
        private readonly IExecuteDataRequestAsync<int, Roles> _getRoles;

        public GetRolesByIdQueryHandler(IExecuteDataRequestAsync<int, Roles> getRoles)
        {
            _getRoles = getRoles;
        }
        public async Task<Roles> ExecuteAsync(int id)
        {
            return await _getRoles.ExecuteAsync(id);

        }
    }
}
