using AutoMapper;
using dCaf.Core;
using PaymentApp.Data.Entities;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PaymentApp.Data.Commands
{

    public class SaveLocation : IExecuteDataRequestAsync<Location, Response<Location>>
    {
        private readonly PaymentAppDbContextCommand _PaymentAppDbContextCommand;
        private readonly IMapper _mapper;
        private readonly Response<Location> _response;

        public SaveLocation(PaymentAppDbContextCommand PaymentAppDbContextCommand,
            IMapper mapper)
        {
            _PaymentAppDbContextCommand = PaymentAppDbContextCommand;
            _mapper = mapper;
            _response = new Response<Location>();
        }

        public async Task<Response<Location>> ExecuteAsync(Location location)
        {

            var duplicateLocation = await _PaymentAppDbContextCommand.Locations
                                                 .FirstOrDefaultAsync(x => x.Name == location.Name);

            if (duplicateLocation != null)
            {
                _response.Result = _mapper.Map<Location>(duplicateLocation); ;

                _response.AddError("Es201", "Location is already Registered");

                return _response;
            }
            else
            {
                var locData = _mapper.Map<LocationEntity>(location);

                _PaymentAppDbContextCommand.Set<LocationEntity>().Add(locData);

                await _PaymentAppDbContextCommand.SaveChangesAsync();

                _response.Result = _mapper.Map<Location>(locData);
            }

            return _response;
        }
    

    }
}