using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
   public class PersonalinfoEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Gender { get; set; }
        public DateTime? DOJ { get; set; }
        public DateTime? DOB { get; set; }
        public int LocationId { get; set; }

    }
}
