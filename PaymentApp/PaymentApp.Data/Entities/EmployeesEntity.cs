using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
    public class EmployeesEntity
    {
        public int Id { get; set; }
        public string AdpFileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LocationId { get; set; }
        public int VisaStatusId { get; set; }
        public string ReferredBy { get; set; }
        public int MarkettingBy { get; set; }
        public DateTime? DOJ { get; set; }
        public DateTime? DOL { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool Status { get; set; }

        public DateTime? PayrollStartDate { get; set; }

        public DateTime? H1wageDate { get; set; }

        public EmployeeProjectEntity? EmployeeProjects { get; set; }
    }
}
