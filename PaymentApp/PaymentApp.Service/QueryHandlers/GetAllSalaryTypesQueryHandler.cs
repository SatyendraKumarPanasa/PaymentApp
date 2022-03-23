using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetAllSalaryTypesQueryHandler : IHandleQueryAsync<List<SalaryType>>
    {
        private readonly IExecuteDataRequestAsync<List<SalaryType>> _getAllSalaryTypes;

        public GetAllSalaryTypesQueryHandler(IExecuteDataRequestAsync<List<SalaryType>> getAllSalaryTypes)
        {
            _getAllSalaryTypes = getAllSalaryTypes;
        }

        public async Task<List<SalaryType>> ExecuteAsync()
        {
            return await _getAllSalaryTypes.ExecuteAsync();
        }
    }
}