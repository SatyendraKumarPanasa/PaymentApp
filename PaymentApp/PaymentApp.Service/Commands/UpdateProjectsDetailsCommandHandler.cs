using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
   public class UpdateProjectsDetailsCommandHandler : IHandleCommandAsync<Projects, Response<Projects>>
    {
        private readonly IExecuteDataRequestAsync<Projects, Response<Projects>> _updateProjectDeatils;

        public UpdateProjectsDetailsCommandHandler(IExecuteDataRequestAsync<Projects, Response<Projects>> updateProjectDeatils)
        {
            _updateProjectDeatils = updateProjectDeatils;
        }

        public async Task<Response<Projects>> ExecuteAsync(Projects projects)
        {
            return await _updateProjectDeatils.ExecuteAsync(projects);
        }
    }
}
