using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace PaymentApp.Data.Queries
{
    public class GetEmployeeById : IExecuteDataRequestAsync<int , Employees>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetEmployeeById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<Employees> ExecuteAsync(int id)
        {
            var employee = await _PaymentAppDbContextQuery.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<Employees>(employee);

        }
    }
}
