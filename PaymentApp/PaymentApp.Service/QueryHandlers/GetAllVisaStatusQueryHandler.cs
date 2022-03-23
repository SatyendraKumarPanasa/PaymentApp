using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetAllVisaStatusQueryHandler : IHandleQueryAsync<List<VisaStatus>>
    {
        private readonly IExecuteDataRequestAsync<List<VisaStatus>> _getAllVisaStatus;

        public GetAllVisaStatusQueryHandler(IExecuteDataRequestAsync<List<VisaStatus>> getAllVisaStatus)
        {
            _getAllVisaStatus = getAllVisaStatus;
        }
        public async Task<List<VisaStatus>> ExecuteAsync()
        {
            return await _getAllVisaStatus.ExecuteAsync();

            
        }
    }
}
