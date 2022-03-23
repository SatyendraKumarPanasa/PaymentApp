using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetEmployeeNotesDetailById : IExecuteDataRequestAsync<int, List<EmployeeNotes>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetEmployeeNotesDetailById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<List<EmployeeNotes>> ExecuteAsync(int id)
        {
            var employeenotes = await _PaymentAppDbContextQuery.EmployeeNotes.Where(x => x.EmployeeId == id).ToListAsync();

            return _mapper.Map<List<EmployeeNotes>>(employeenotes);
        }
    }
}
