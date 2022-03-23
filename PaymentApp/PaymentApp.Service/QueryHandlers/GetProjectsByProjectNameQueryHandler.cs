using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetProjectsByProjectNameQueryHandler : IHandleQueryAsync<ProjectSearch, List<Projects>>
    {
        private readonly IExecuteDataRequestAsync<ProjectSearch, List<Projects>> _getProjectDetail;

        public GetProjectsByProjectNameQueryHandler(IExecuteDataRequestAsync<ProjectSearch, List<Projects>> getProjectDetail)
        {
            _getProjectDetail = getProjectDetail;
        }

        public async Task<List<Projects>> ExecuteAsync(ProjectSearch projectSearch)
        {
            return await _getProjectDetail.ExecuteAsync(projectSearch);
        }
    }
}
