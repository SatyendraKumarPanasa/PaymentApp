using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetEmployeeNotesDetailByIdQueryHandler : IHandleQueryAsync<int, List<EmployeeNotes>>
    {
        private readonly IExecuteDataRequestAsync<int, List<EmployeeNotes>> _getEmployeeNotes;

        public GetEmployeeNotesDetailByIdQueryHandler(IExecuteDataRequestAsync<int, List<EmployeeNotes>> getEmployeeNotes)
        {
            _getEmployeeNotes = getEmployeeNotes;
        }
        public async Task<List<EmployeeNotes>> ExecuteAsync(int id)
        {
            return await _getEmployeeNotes.ExecuteAsync(id);
        }
    }
}
