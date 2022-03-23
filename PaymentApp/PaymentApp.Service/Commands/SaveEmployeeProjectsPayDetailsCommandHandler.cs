using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
    public class SaveEmployeeProjectsPayDetailsCommandHandler : IHandleCommandAsync<EmployeeProjectPayDetails, Response<EmployeeProjectPayDetails>>
    {

        private readonly IExecuteDataRequestAsync<EmployeeProjectPayDetails, Response<EmployeeProjectPayDetails>> _saveEmpProjectpaydetails;

        public SaveEmployeeProjectsPayDetailsCommandHandler(IExecuteDataRequestAsync<EmployeeProjectPayDetails, Response<EmployeeProjectPayDetails>> saveEmpProjectpaydetails)
        {
            _saveEmpProjectpaydetails = saveEmpProjectpaydetails;
        }
        public async Task<Response<EmployeeProjectPayDetails>> ExecuteAsync(EmployeeProjectPayDetails employeeProjectPayDetails)
        {
            return await _saveEmpProjectpaydetails.ExecuteAsync(employeeProjectPayDetails);
        }
    }
}
