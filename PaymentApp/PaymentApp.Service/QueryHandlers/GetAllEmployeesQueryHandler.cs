using System;
using System.Collections.Generic;
using PaymentApp.Core.DomainModels;
using System.Text;
using System.Threading.Tasks;
using dCaf.Core;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetAllEmployeesQueryHandler : IHandleQueryAsync<List<Employees>>
    {
        private readonly IExecuteDataRequestAsync<List<Employees>> _getAllEmployees;

        public GetAllEmployeesQueryHandler(IExecuteDataRequestAsync<List<Employees>> getAllEmployees)
        {
            _getAllEmployees = getAllEmployees;
        }

        public async Task<List<Employees>> ExecuteAsync()
        {
            return await _getAllEmployees.ExecuteAsync();
        }
    }
}