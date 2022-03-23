using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetEmployeeTypeByIdQueryHandler : IHandleQueryAsync<int, EmployeeType>
    {
        private readonly IExecuteDataRequestAsync<int, EmployeeType> _getEmployeeType;

        public GetEmployeeTypeByIdQueryHandler(IExecuteDataRequestAsync<int, EmployeeType> getemployee)
        {
            _getEmployeeType = getemployee;
        }
        public async Task<EmployeeType> ExecuteAsync(int id)
        {
            var employee = await _getEmployeeType.ExecuteAsync(id);

            return employee;
        }
    }
}
