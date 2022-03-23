using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetAllProjectStatusQueryHandler : IHandleQueryAsync<List<ProjectStatus>>
    {

        private readonly IExecuteDataRequestAsync<List<ProjectStatus>> _getAllProjectStatus;

        public GetAllProjectStatusQueryHandler(IExecuteDataRequestAsync<List<ProjectStatus>> getAllProjectStatus)
        {
            _getAllProjectStatus = getAllProjectStatus;
        }

        public async Task<List<ProjectStatus>> ExecuteAsync()
        {
            return await _getAllProjectStatus.ExecuteAsync();
        }
    }
}
