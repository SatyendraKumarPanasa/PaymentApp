using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApp.Core.DomainModels
{
    public class EmployeeNotes
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Notes { get; set; }
    }
}
