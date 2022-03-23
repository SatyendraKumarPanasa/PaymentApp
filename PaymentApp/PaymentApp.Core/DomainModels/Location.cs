using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApp.Core.DomainModels
{
    public class Location
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }


      
        public int Code { get; set; }
    }
}
