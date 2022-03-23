using AutoMapper;
using dCaf.Core;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
    public class SaveEmployeeprojectsData : IExecuteDataRequestAsync<EmployeeProject, Response<EmployeeProject>>
    {

        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;
        private readonly Response<EmployeeProject> _response;

        public SaveEmployeeprojectsData(PaymentAppDbContextCommand PaymentAppDbContextCommand, PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
            _response = new Response<EmployeeProject>()
            {
                Errors = new Dictionary<string, string[]>()
            };
        }
        public async Task<Response<EmployeeProject>> ExecuteAsync(EmployeeProject employeeProject)
        {
            Vendors vendors = new Vendors();
            var vendor = await _PaymentAppDbContextQuery.Vendors.Where(x => x.Name == employeeProject.Vendor1Id).FirstOrDefaultAsync();

            vendors =  _mapper.Map<Vendors>(vendor);

            if (vendors == null)
            {
              _response.AddError("Es201", "Vendor Not Found");
                return _response;
            }

            Vendors vendor2 = new Vendors();
            var vendor2Id = await _PaymentAppDbContextQuery.Vendors.Where(x => x.Name == employeeProject.Vendor2Id).FirstOrDefaultAsync();

            vendor2 = _mapper.Map<Vendors>(vendor2Id);

            if (vendor2 == null)
            {
                _response.AddError("Es201", "Vendor Not Found");
                return _response;
            }


            Clients clients = new Clients();
            var client = await _PaymentAppDbContextQuery.clients.Where(x => x.Name == employeeProject.EndClientId).FirstOrDefaultAsync();
            var clientid = _mapper.Map<Clients>(client);

            if (clientid == null)
            {
                _response.AddError("Es201", "Client Not Found");
                return _response;
            }


            var mapEmpprojectData = _mapper.Map<EmployeeProjectEntity>(employeeProject);

            mapEmpprojectData.Vendor1Id = vendors.Id;
            mapEmpprojectData.Vendor2Id = vendors.Id;
            mapEmpprojectData.EndClientId = clientid.Id;

            _PaymentAppDbContextCommand.EmployeeProjects.Add(mapEmpprojectData);

            await _PaymentAppDbContextCommand.SaveChangesAsync();

            _response.Result = _mapper.Map<EmployeeProject>(mapEmpprojectData);

            return _response;
        }
    }
}
