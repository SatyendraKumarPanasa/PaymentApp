using AutoMapper;
using dCaf.Core;
using PaymentApp.Core.DomainModels;
using PaymentApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data.Commands
{
    public class SaveEmployeeprojectPayDetails : IExecuteDataRequestAsync<EmployeeProjectPayDetails, Response<EmployeeProjectPayDetails>>
    {

        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly IMapper _mapper;
        private readonly Response<EmployeeProjectPayDetails> _response;

        public SaveEmployeeprojectPayDetails(PaymentAppDbContextCommand PaymentAppDbContextCommand, IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _mapper = mapper;
            _response = new Response<EmployeeProjectPayDetails>();
        }
        public async Task<Response<EmployeeProjectPayDetails>> ExecuteAsync(EmployeeProjectPayDetails employeeProjectPayDetails)
        {
            var empProjPayData = _mapper.Map<EmployeeProjectPayDetailsEntity>(employeeProjectPayDetails);
            _PaymentAppDbContextCommand.EmployeeProjectPayDetails.Add(empProjPayData);

            await _PaymentAppDbContextCommand.SaveChangesAsync();

            _response.Result = _mapper.Map<EmployeeProjectPayDetails>(empProjPayData);

            return _response;
        }
    }
}
