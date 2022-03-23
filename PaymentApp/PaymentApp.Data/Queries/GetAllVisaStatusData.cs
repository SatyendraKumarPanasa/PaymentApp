using AutoMapper;
using dCaf.Core;
using PaymentApp.Data.Entities;
using PaymentApp.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetAllVisaStatusData : IExecuteDataRequestAsync<List<VisaStatus>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllVisaStatusData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<VisaStatus>> ExecuteAsync()
        {
            List<VisaStatus> visaStatus = new List<VisaStatus>();
            var res=  await _PaymentAppDbContextQuery.VisaStatus.ToListAsync();

            visaStatus = _mapper.Map<List<VisaStatus>>(res);

            return visaStatus;
        }
    }
}
