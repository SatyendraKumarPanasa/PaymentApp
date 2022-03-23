using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetAllProjectsQueryHandler : IHandleQueryAsync<List<Projects>>
    {
        private readonly IExecuteDataRequestAsync<List<Projects>> _getAllProjects;

        public GetAllProjectsQueryHandler(IExecuteDataRequestAsync<List<Projects>> getAllProjects)
        {
            _getAllProjects = getAllProjects;
        }

        public async Task<List<Projects>> ExecuteAsync()
        {
            return await _getAllProjects.ExecuteAsync();
        }
    }
}