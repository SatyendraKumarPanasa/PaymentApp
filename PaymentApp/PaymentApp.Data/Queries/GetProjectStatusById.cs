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
    public class GetProjectStatusById : IExecuteDataRequestAsync<int, ProjectStatus>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetProjectStatusById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<ProjectStatus> ExecuteAsync(int id)
        {
            var projectStatus = await _PaymentAppDbContextQuery.ProjectStatus.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ProjectStatus>(projectStatus);
        }
    }
}
