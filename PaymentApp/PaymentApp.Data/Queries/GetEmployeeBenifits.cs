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
    public class GetEmployeeBenifits : IExecuteDataRequestAsync<int, Benfits>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetEmployeeBenifits(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<Benfits> ExecuteAsync(int id)
        {
            var benifit = await _PaymentAppDbContextQuery.Benfits.Where(x => x.Id == id).FirstOrDefaultAsync();

            var employeeBenifit = _mapper.Map<Benfits>(benifit);

            return employeeBenifit;
        }
    }
}
