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
    public class GetAllSalaryTypesData : IExecuteDataRequestAsync<List<SalaryType>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllSalaryTypesData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<SalaryType>> ExecuteAsync()
        {
            List<SalaryType> salarytype = new List<SalaryType>();
            var res = await _PaymentAppDbContextQuery.SalaryType.ToListAsync();

            salarytype = _mapper.Map<List<SalaryType>>(res);

            return salarytype;

        }
    }
}