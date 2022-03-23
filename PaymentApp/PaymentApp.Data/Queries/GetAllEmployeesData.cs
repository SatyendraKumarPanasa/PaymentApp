using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetAllEmployeesData : IExecuteDataRequestAsync<List<Employees>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllEmployeesData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<Employees>> ExecuteAsync()
        {
            List<Employees> employees = new List<Employees>();
            var res = await _PaymentAppDbContextQuery.Employees.ToListAsync();

            employees = _mapper.Map<List<Employees>>(res);

            return employees;
        }
    }
}
