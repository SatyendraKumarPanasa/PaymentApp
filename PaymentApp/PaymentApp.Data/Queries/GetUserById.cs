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
    public class GetUserById : IExecuteDataRequestAsync<int, Users>
    {
        private readonly PaymentAppDbContextQuery _PaymentAppDbContextQuery;
        private readonly IMapper _mapper;

        public GetUserById(PaymentAppDbContextQuery PaymentAppDbContextQuery, IMapper mapper)
        {
            _PaymentAppDbContextQuery = PaymentAppDbContextQuery;
            _mapper = mapper;
        }


        public async Task<Users> ExecuteAsync(int id)
        {
            var users = await _PaymentAppDbContextQuery.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<Users>(users);
        }
    }
}
