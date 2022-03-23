using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    class GetEmployeesProjectPayDetailByIdQueryHandler : IHandleQueryAsync<int, List<EmployeeProjectPayDetails>>
    {
        private readonly IExecuteDataRequestAsync<int, List<EmployeeProjectPayDetails>> _getEmployeeProjectPayDetails;

        public GetEmployeesProjectPayDetailByIdQueryHandler(IExecuteDataRequestAsync<int, List<EmployeeProjectPayDetails>> getEmployeeProjectPayDetails)
        {
            _getEmployeeProjectPayDetails = getEmployeeProjectPayDetails;
        }
        public async Task<List<EmployeeProjectPayDetails>> ExecuteAsync(int id)
        {
            return await _getEmployeeProjectPayDetails.ExecuteAsync(id);
        }
    }
}
