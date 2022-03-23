using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
   public class UpdateProjectsData : IExecuteDataRequestAsync<Projects, Response<Projects>>
    {
        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;
        private readonly Response<Projects> _response;

        public UpdateProjectsData(PaymentAppDbContextCommand PaymentAppDbContextCommand, PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
            _response = new Response<Projects>();
        }
        public async Task<Response<Projects>> ExecuteAsync(Projects projects)
        {
            var prjData = await _PaymentAppDbContextQuery.Projects
                                    .FirstOrDefaultAsync(x => x.Id == projects.Id);

            if (prjData == null)
            {
                _response.Result = _mapper.Map<Projects>(prjData);

                _response.AddError("Es201", "Project is Not Assigned for this Employee");

                return _response;
            }
            else
            {
                var mapPrjData = _mapper.Map<ProjectsEntity>(projects);
                prjData.Name = mapPrjData.Name;
                prjData.StartDate = mapPrjData.StartDate;
                prjData.EndDate = mapPrjData.EndDate;
                prjData.Status = true;
                _PaymentAppDbContextCommand.Projects.Update(prjData);

                await _PaymentAppDbContextCommand.SaveChangesAsync();

                _response.Result = _mapper.Map<Projects>(prjData);
            }

            return _response;

        }
    }
}
