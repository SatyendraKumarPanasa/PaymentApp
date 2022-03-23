using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetEmployeeByIdQueryHandler : IHandleQueryAsync<int, Employees>
    {
        private readonly IExecuteDataRequestAsync<int, Employees> _getEmployeeType;

        public GetEmployeeByIdQueryHandler(IExecuteDataRequestAsync<int, Employees> getemployee)
        {
            _getEmployeeType = getemployee;
        }
        public async Task<Employees> ExecuteAsync(int id)
        {
            var employee = await _getEmployeeType.ExecuteAsync(id);

            return employee;
        }
    }
}
