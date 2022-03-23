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
    public class GetEmployeesProjectPayDetailById : IExecuteDataRequestAsync<int, List<EmployeeProjectPayDetails>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetEmployeesProjectPayDetailById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<List<EmployeeProjectPayDetails>> ExecuteAsync(int id)
        {
            var employeeDetails = await _PaymentAppDbContextQuery.EmployeeProjectPayDetails.Where(x => x.Id == id).ToListAsync();

            return _mapper.Map<List<EmployeeProjectPayDetails>>(employeeDetails);
        }
    }
}
