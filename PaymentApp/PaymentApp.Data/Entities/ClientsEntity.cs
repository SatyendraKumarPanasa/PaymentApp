using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
    public class ClientsEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public EmployeeProjectEntity? EmployeeProjects { get; set; }
    }
}
