using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Queries
{
    public class GetProjectsByProjectName : IExecuteDataRequestAsync<ProjectSearch, List<Projects>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetProjectsByProjectName(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<List<Projects>> ExecuteAsync(ProjectSearch projectSearch)
        {
            var projectsData = await _PaymentAppDbContextQuery.Projects.
                Where(x =>
            (string.IsNullOrEmpty(projectSearch.ProjectName) ? x.Name == x.Name : x.Name == projectSearch.ProjectName)).ToListAsync();

           var  projectsNames = _mapper.Map<List<Projects>>(projectsData);

            return projectsNames;
        }
    }
}
