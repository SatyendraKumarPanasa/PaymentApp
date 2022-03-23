using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetProjectsByIdQueryHandler : IHandleQueryAsync<int, List<Projects>>
    {
        private readonly IExecuteDataRequestAsync<int, List<Projects>> _getProjectDetail;

        public GetProjectsByIdQueryHandler(IExecuteDataRequestAsync<int, List<Projects>> getProjectDetail)
        {
            _getProjectDetail = getProjectDetail;
        }
        public async Task<List<Projects>> ExecuteAsync(int id)
        {
            return await _getProjectDetail.ExecuteAsync(id);

        }
    }
}
