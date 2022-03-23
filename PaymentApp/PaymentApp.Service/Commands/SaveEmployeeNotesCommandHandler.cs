using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.Commands
{
    public class SaveEmployeeNotesCommandHandler : IHandleCommandAsync<EmployeeNotes, Response<EmployeeNotes>>
    {

        private readonly IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>> _saveEmployeeNotes;

        public SaveEmployeeNotesCommandHandler(IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>> saveEmployeeNotes)
        {
            _saveEmployeeNotes = saveEmployeeNotes;
        }

        public async Task<Response<EmployeeNotes>> ExecuteAsync(EmployeeNotes EmployeeNotes)
        {
            return await _saveEmployeeNotes.ExecuteAsync(EmployeeNotes);
        }
    }
}
