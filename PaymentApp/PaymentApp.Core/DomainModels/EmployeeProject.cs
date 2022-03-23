using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Core.DomainModels
{
    public class EmployeeProject
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string Vendor1Id { get; set; }
        public string Vendor2Id { get; set; }
        public string EndClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectStatusID { get; set; }
    }
}
