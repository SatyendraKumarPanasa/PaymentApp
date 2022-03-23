using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetAllProjectStatusData : IExecuteDataRequestAsync<List<ProjectStatus>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllProjectStatusData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<ProjectStatus>> ExecuteAsync()
        {
            List<ProjectStatus> projectStatuses = new List<ProjectStatus>();
            var ret = await _PaymentAppDbContextQuery.ProjectStatus.ToListAsync();

            projectStatuses = _mapper.Map<List<ProjectStatus>>(ret);

            return projectStatuses;
        }
    }
}
