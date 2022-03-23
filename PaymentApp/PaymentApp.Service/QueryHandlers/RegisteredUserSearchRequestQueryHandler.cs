using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class RegisteredUserSearchRequestQueryHandler : IHandleQueryAsync<UserSearchRequest, List<Users>>
    {


        private readonly IExecuteDataRequestAsync<UserSearchRequest, List<Users>> _getRegisteredUserData;

        public RegisteredUserSearchRequestQueryHandler(IExecuteDataRequestAsync<UserSearchRequest, List<Users>> getRegisteredUserData)
        {
            _getRegisteredUserData = getRegisteredUserData;
        }
        public async Task<List<Users>> ExecuteAsync(UserSearchRequest userSearchRequest)
        {
            var regUserData = await _getRegisteredUserData.ExecuteAsync(userSearchRequest);

            return regUserData;
        }
    }
}
