using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApp.Core.DomainModels
{
    public class Employees
    {

        public int Id { get; set; }
        [StringLength(10)]
        public string AdpFileNumber { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        public int LocationId { get; set; }
        public int VisaStatusId { get; set; }

        [StringLength(50)]
        public string ReferredBy { get; set; }
        public int MarkettingBy { get; set; }
        public DateTime? DOJ { get; set; }
        public DateTime? DOL { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool Status { get; set; }

        public DateTime? PayrollStartDate { get; set; }

        public DateTime? H1wageDate { get; set; }

    }
}
