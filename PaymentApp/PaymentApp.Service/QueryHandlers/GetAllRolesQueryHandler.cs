using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetAllRolesQueryHandler : IHandleQueryAsync<List<Roles>>
    {

        private readonly IExecuteDataRequestAsync<List<Roles>> _getAllRoles;

        public GetAllRolesQueryHandler(IExecuteDataRequestAsync<List<Roles>> getAllRoles)
        {
            _getAllRoles = getAllRoles;
        }
        public async Task<List<Roles>> ExecuteAsync()
        {
            return await _getAllRoles.ExecuteAsync();
        }
    }
}
