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
   public class GetAllLocationsData  : IExecuteDataRequestAsync<List<Location>>
    {

        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetAllLocationsData(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<List<Location>> ExecuteAsync()
        {
            List<Location> locations = new List<Location>();
            var ret = await _PaymentAppDbContextQuery.Locations.ToListAsync();

            locations = _mapper.Map<List<Location>>(ret);

            return locations;
        }
    }
}
