using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
    public class EmployeeNotesEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Notes { get; set; }
    }
}
