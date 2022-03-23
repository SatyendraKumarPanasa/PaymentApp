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
   public class GetAllEmployeeTypesData : IExecuteDataRequestAsync<List<EmployeeType>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllEmployeeTypesData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<List<EmployeeType>> ExecuteAsync()
        {
            List<EmployeeType> employeeTypes = new List<EmployeeType>();
            var ret = await _PaymentAppDbContextQuery.EmployeeType.ToListAsync();

            employeeTypes = _mapper.Map<List<EmployeeType>>(ret);

            return employeeTypes;
        }
    }
}
