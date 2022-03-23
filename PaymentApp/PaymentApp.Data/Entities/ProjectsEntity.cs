using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
    public class ProjectsEntity
    {                                                                                                        
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public bool Status { get; set; }

        public EmployeeProjectEntity? EmployeeProjects { get; set; }
    }
}
