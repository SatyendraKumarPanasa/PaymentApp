using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
    public class SaveProjectsData : IExecuteDataRequestAsync<Projects, Response<Projects>>
    {
        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly IMapper _mapper;
        private readonly Response<Projects> _response;

        public SaveProjectsData(PaymentAppDbContextCommand PaymentAppDbContextCommand, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _mapper = mapper;
            _response = new Response<Projects>();
        }

        public async Task<Response<Projects>> ExecuteAsync(Projects projects)
        {
            var mapProjectData = _mapper.Map<ProjectsEntity>(projects);

            _PaymentAppDbContextCommand.Set<ProjectsEntity>().Add(mapProjectData);

            await _PaymentAppDbContextCommand.SaveChangesAsync();

            _response.Result = _mapper.Map<Projects>(mapProjectData);

            return _response;

        }


    }
}