using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
    public class EmployeeProjectEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int Vendor1Id { get; set; }
        public int Vendor2Id { get; set; }
        public int EndClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectStatusID { get; set; }

        public EmployeesEntity? Employees { get; set; }

        public ProjectsEntity? projects { get; set; }

        public VendorsEntity? vendors { get; set; }

        public ClientsEntity? clients { get; set; }
    }
}
