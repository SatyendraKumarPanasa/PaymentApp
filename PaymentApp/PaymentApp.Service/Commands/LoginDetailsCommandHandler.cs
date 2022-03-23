using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
    public class LoginDetailsCommandHandler : IHandleCommandAsync<LoginViewModel, LoginViewModel>
    {

        private readonly IExecuteDataRequestAsync<LoginViewModel, LoginViewModel> _loginDeatils;

        public LoginDetailsCommandHandler(IExecuteDataRequestAsync<LoginViewModel, LoginViewModel> loginDeatils)
        {
            _loginDeatils = loginDeatils;
        }
        public async Task<LoginViewModel> ExecuteAsync(LoginViewModel loginViewModel)
        {
            return await _loginDeatils.ExecuteAsync(loginViewModel);
        }
    }
}
