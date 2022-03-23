using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Service.Commands
{
    public class SaveProjectDetailsCommandHandler : IHandleCommandAsync<Projects, Response<Projects>>
    {
        private readonly IExecuteDataRequestAsync<Projects, Response<Projects>> _saveProject;

        public SaveProjectDetailsCommandHandler(IExecuteDataRequestAsync<Projects, Response<Projects>> saveProject)
        {
            _saveProject = saveProject;
        }
        public async Task<Response<Projects>> ExecuteAsync(Projects projects)
        {
            return await _saveProject.ExecuteAsync(projects);
        }
    }
}