using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data
{
  public  class PaymentAppDbContextCommand : PaymentAppDbContext<PaymentAppDbContextCommand>
    {
        public PaymentAppDbContextCommand(DbContextOptions<PaymentAppDbContextCommand> options)
           : base(options)
        {
        }
    }
}
