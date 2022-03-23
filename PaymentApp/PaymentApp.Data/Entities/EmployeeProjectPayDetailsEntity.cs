using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
    public class EmployeeProjectPayDetailsEntity
    {
        public int Id { get; set; }
        public int EmployeeProjectId { get; set; }
        public int SalaryTypeId { get; set; }
        public decimal BillRate { get; set; }
        public decimal H1Wages { get; set; }
        public decimal SalaryOffered { get; set; }
        public decimal PayPercentage { get; set; }
        public decimal HourlyRate { get; set; }
        public bool PTO { get; set; }
        public bool InsurenceByUS { get; set; }

    }
}
