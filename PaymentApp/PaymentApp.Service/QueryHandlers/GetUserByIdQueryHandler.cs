using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetUserByIdQueryHandler : IHandleQueryAsync<int, Users>
    {
        private readonly IExecuteDataRequestAsync<int, Users> _getUser;

        public GetUserByIdQueryHandler(IExecuteDataRequestAsync<int, Users> getUser)
        {
            _getUser = getUser;
        }
        public async Task<Users> ExecuteAsync(int id)
        {
            return await _getUser.ExecuteAsync(id);

        }
    }
}
