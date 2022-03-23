using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
   public class GetAllEmployeeTypesQueryHandler: IHandleQueryAsync<List<EmployeeType>>
    {
        private readonly IExecuteDataRequestAsync<List<EmployeeType>> _getAllEmployeeTypes;

        public GetAllEmployeeTypesQueryHandler(IExecuteDataRequestAsync<List<EmployeeType>> getAllEmployeeTypes)
        {
            _getAllEmployeeTypes = getAllEmployeeTypes;
        }

        public async Task<List<EmployeeType>> ExecuteAsync()
        {
            return await _getAllEmployeeTypes.ExecuteAsync();
        }
    }
}
