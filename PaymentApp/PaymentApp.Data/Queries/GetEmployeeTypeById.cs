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
    public class GetEmployeeTypeById : IExecuteDataRequestAsync<int, EmployeeType>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetEmployeeTypeById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<EmployeeType> ExecuteAsync(int id)
        {
            var employeeType = await _PaymentAppDbContextQuery.EmployeeType.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<EmployeeType>(employeeType);

        }
    }
}
