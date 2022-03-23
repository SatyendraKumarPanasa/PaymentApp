using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
    public class SaveEmployeeNotesData : IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>>
    {

        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly IMapper _mapper;
        private readonly Response<EmployeeNotes> _response;

        public SaveEmployeeNotesData(PaymentAppDbContextCommand PaymentAppDbContextCommand, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _mapper = mapper;
            _response = new Response<EmployeeNotes>();
        }
        public async Task<Response<EmployeeNotes>> ExecuteAsync(EmployeeNotes employeeNotes)
        {
            var duplicateEmployee = await _PaymentAppDbContextCommand.EmployeeNotes.
                FirstOrDefaultAsync(x => x.EmployeeId == employeeNotes.EmployeeId);

            if(duplicateEmployee != null)
            {
                _response.Result = _mapper.Map<EmployeeNotes>(duplicateEmployee); ;

                _response.AddError("Es201", "Notes are already Existed for Employee");

                return _response;
            }
            else
            {
                var empNotesData = _mapper.Map<EmployeeNotesEntity>(employeeNotes);
                _PaymentAppDbContextCommand.EmployeeNotes.Add(empNotesData);

                await _PaymentAppDbContextCommand.SaveChangesAsync();

                _response.Result = _mapper.Map<EmployeeNotes>(empNotesData);
            }

            return _response;
        }

    }
}
