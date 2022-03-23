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
    public class GetMemberLocations : IExecuteDataRequestAsync<int, List<Location>>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetMemberLocations(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<List<Location>> ExecuteAsync(int id)
        {
            var locList = await _PaymentAppDbContextQuery.Locations.Where(x => x.Id == id).ToListAsync();

            var locations = _mapper.Map<List<Location>>(locList);

            return locations;
        }
    }
}
