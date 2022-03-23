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
    public class GetVisaStatusById : IExecuteDataRequestAsync<int, VisaStatus>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetVisaStatusById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<VisaStatus> ExecuteAsync(int id)
        {
            var visaStatus = await _PaymentAppDbContextQuery.VisaStatus.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<VisaStatus>(visaStatus);
        }
    }
}
