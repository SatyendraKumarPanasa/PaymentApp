using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Core.DomainModels
{
  public  class EmployeeSearchRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ADPFileNo { get; set; }

        public int? employeetypeId { get; set; }

        public int? VisastatusID { get; set; }

        public int? locationId { get; set; }
    }
}
