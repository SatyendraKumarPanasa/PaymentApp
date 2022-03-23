using PaymentApp.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Service
{
    public interface IGetLocationsByIdQueryHandler
    {
        public Task<List<Location>> ExecuteAsync(int id);
    }
}
