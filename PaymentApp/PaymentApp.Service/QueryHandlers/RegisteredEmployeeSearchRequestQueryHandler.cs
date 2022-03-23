using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class RegisteredEmployeeSearchRequestQueryHandler : IHandleQueryAsync<EmployeeSearchRequest, List<Employees>>
     {
        private readonly IExecuteDataRequestAsync<EmployeeSearchRequest, List<Employees>> _getRegisteredEmployeeData;

        public RegisteredEmployeeSearchRequestQueryHandler(IExecuteDataRequestAsync<EmployeeSearchRequest, List<Employees>> getRegisteredEmployeeData)
        {
            _getRegisteredEmployeeData = getRegisteredEmployeeData;
        }


        public async Task<List<Employees>> ExecuteAsync(EmployeeSearchRequest request)
        {
           
                var regEmpData = await _getRegisteredEmployeeData.ExecuteAsync(request);

                return regEmpData;
        }
    }
}
