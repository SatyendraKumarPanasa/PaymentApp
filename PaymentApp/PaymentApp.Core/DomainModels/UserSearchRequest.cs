using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Core.DomainModels
{
   public class UserSearchRequest
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? RoleId { get; set; }
    }
}
