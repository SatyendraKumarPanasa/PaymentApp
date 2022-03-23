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
   public class UpdateEmployeeNotesData : IExecuteDataRequestAsync<EmployeeNotes, Response<EmployeeNotes>>
    {
        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;
        private readonly Response<EmployeeNotes> _response;

        public UpdateEmployeeNotesData(PaymentAppDbContextCommand PaymentAppDbContextCommand, PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
            _response = new Response<EmployeeNotes>();
        }
        public async Task<Response<EmployeeNotes>> ExecuteAsync(EmployeeNotes employeeNotes)
        {
            var empNotesData = await _PaymentAppDbContextQuery.EmployeeNotes
                                    .FirstOrDefaultAsync(x => x.Id == employeeNotes.Id);

            if (empNotesData == null)
            {
                _response.Result = _mapper.Map<EmployeeNotes>(empNotesData);

                _response.AddError("Es201", "Notes are there for this Employee");

                return _response;
            }
            else
            {
                var mapEmpNotesData = _mapper.Map<EmployeeNotesEntity>(employeeNotes);
                empNotesData.EmployeeId = mapEmpNotesData.EmployeeId;
                empNotesData.Notes = mapEmpNotesData.Notes;



                _PaymentAppDbContextCommand.EmployeeNotes.Update(empNotesData);

                await _PaymentAppDbContextCommand.SaveChangesAsync();

                _response.Result = _mapper.Map<EmployeeNotes>(empNotesData);
            }

            return _response;

        }
    }
}
