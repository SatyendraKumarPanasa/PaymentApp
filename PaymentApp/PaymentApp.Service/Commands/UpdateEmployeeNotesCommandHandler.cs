using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
   public class UpdateEmployeeNotesCommandHandler : IHandleCommandAsync<EmployeeNotes, Response<EmployeeNotes>>
    {

        private readonly IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>> _updateEmployeeNotes;

        public UpdateEmployeeNotesCommandHandler(IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>> updateEmployeeNotes)
        {
            _updateEmployeeNotes = updateEmployeeNotes;
        }

        public async Task<Response<EmployeeNotes>> ExecuteAsync(EmployeeNotes EmployeeNotes)
        {
            return await _updateEmployeeNotes.ExecuteAsync(EmployeeNotes);
        }
    }
}
