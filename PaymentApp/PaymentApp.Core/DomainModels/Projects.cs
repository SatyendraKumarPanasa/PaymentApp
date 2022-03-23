using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApp.Core.DomainModels
{
    public class Projects
    {                                                                                                        
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public bool Status { get; set; }
    }
}
