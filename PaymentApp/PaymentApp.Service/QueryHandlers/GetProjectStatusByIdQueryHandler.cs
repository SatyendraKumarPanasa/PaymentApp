using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetProjectStatusByIdQueryHandler : IHandleQueryAsync<int, ProjectStatus>
    {
        private readonly IExecuteDataRequestAsync<int, ProjectStatus> _getProjectStatus;

        public GetProjectStatusByIdQueryHandler(IExecuteDataRequestAsync<int, ProjectStatus> getProjectStatus)
        {
            _getProjectStatus = getProjectStatus;
        }
        public async Task<ProjectStatus> ExecuteAsync(int id)
        {
            return await _getProjectStatus.ExecuteAsync(id);

        }
    }
}
