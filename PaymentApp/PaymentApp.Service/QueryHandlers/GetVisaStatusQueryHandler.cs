using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetVisaStatusQueryHandler : IHandleQueryAsync<int, VisaStatus>
    {
        private readonly IExecuteDataRequestAsync<int, VisaStatus> _getVisaStatus;

        public GetVisaStatusQueryHandler(IExecuteDataRequestAsync<int, VisaStatus> getVisaStatus)
        {
            _getVisaStatus = getVisaStatus;
        }
        public async Task<VisaStatus> ExecuteAsync(int id)
        {
            return await _getVisaStatus.ExecuteAsync(id);

        }
    }
}
