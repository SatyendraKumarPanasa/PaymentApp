using dCaf.Core;
using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service.QueryHandlers
{
    public class GetBenifitByIdQueryHandler : IHandleQueryAsync<int, Benfits>
    {
        private readonly IExecuteDataRequestAsync<int, Benfits> _getBenifit;

        public GetBenifitByIdQueryHandler(IExecuteDataRequestAsync<int, Benfits> getBenifit)
        {
            _getBenifit = getBenifit;
        }
        public async Task<Benfits> ExecuteAsync(int id)
        {
            var benfits = await _getBenifit.ExecuteAsync(id);

            return benfits;
        }
    }
}
