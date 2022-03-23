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
    public class GetClientById : IExecuteDataRequestAsync<int, Clients>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetClientById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }

        public async Task<Clients> ExecuteAsync(int id)
        {
            var client = await _PaymentAppDbContextQuery.clients.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<Clients>(client);

        }
    }
}
