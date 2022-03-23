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
    public class GetEmployeeProjectById : IExecuteDataRequestAsync<int, EmployeeProject>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetEmployeeProjectById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<EmployeeProject> ExecuteAsync(int id)
        {
            var employeeProject = await _PaymentAppDbContextQuery.EmployeeProjects.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<EmployeeProject>(employeeProject);

        }
    }
}
