using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data
{
    public class PaymentAppDbContextQuery : PaymentAppDbContext<PaymentAppDbContextQuery>
    {
        public PaymentAppDbContextQuery(DbContextOptions<PaymentAppDbContextQuery> options)
           : base(options)
        {
        }
    }
}
