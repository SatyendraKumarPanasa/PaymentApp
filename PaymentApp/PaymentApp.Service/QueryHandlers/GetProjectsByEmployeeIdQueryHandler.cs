using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetProjectsByEmployeeIdQueryHandler : IHandleQueryAsync<int, List<ListEmployeeProjects>>
    {
        private readonly IExecuteDataRequestAsync<int, List<ListEmployeeProjects>> _getEmployeeProjects;

        public GetProjectsByEmployeeIdQueryHandler(IExecuteDataRequestAsync<int, List<ListEmployeeProjects>> getEmployeeProjects)
        {
            _getEmployeeProjects = getEmployeeProjects;
        }

        public async Task<List<ListEmployeeProjects>> ExecuteAsync(int id)
        {
            var empPrjData = await _getEmployeeProjects.ExecuteAsync(id);

            return empPrjData;
        }
    }
}
