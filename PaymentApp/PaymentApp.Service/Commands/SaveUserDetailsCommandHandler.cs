using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
    public class SaveUserDetailsCommandHandler : IHandleCommandAsync<Users, Response<Users>>
    {
        private readonly IExecuteDataRequestAsync<Users, Response<Users>> _saveUserDeatils;


        public SaveUserDetailsCommandHandler(IExecuteDataRequestAsync<Users, Response<Users>> saveUserDeatils)
        {
            _saveUserDeatils = saveUserDeatils;
        }

        public async Task<Response<Users>> ExecuteAsync(Users users)
        {
            return await _saveUserDeatils.ExecuteAsync(users);
        }
    }
}
