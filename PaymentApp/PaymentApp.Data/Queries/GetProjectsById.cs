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
    public class GetProjectsById : IExecuteDataRequestAsync<int, List<Projects>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetProjectsById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<List<Projects>> ExecuteAsync(int id)
        {
            List<Projects> projects = new List<Projects>();

            var sunny = await _PaymentAppDbContextQuery.Projects.Where(x => x.Id == id).ToListAsync();

            projects = _mapper.Map<List<Projects>>(sunny);

            return projects;
        }
    }
}
