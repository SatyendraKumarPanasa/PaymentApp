using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
   public class GetAllEmployeeProjectsQueryHandler : IHandleQueryAsync<List<ListEmployeeProjects>>
    {
        private readonly IExecuteDataRequestAsync<List<ListEmployeeProjects>> _getAllEmployeeProjects;

        public GetAllEmployeeProjectsQueryHandler(IExecuteDataRequestAsync<List<ListEmployeeProjects>> getAllEmployeeProjects)
        {
            _getAllEmployeeProjects = getAllEmployeeProjects;
        }

        public async Task<List<ListEmployeeProjects>> ExecuteAsync()
        {
            return await _getAllEmployeeProjects.ExecuteAsync();
        }
    }
    
}
