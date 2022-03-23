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
    public class GetAllProjectsData : IExecuteDataRequestAsync<List<Projects>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllProjectsData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }
        public async Task<List<Projects>> ExecuteAsync()
        {
            List<Projects> projects = new List<Projects>();
            var res = await _PaymentAppDbContextQuery.Projects.ToListAsync();
            projects = _mapper.Map<List<Projects>>(res);
            return projects;

        }
    }


}