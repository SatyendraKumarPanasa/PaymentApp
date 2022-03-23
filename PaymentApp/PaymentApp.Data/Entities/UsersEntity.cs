using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Data.Entities
{
    public class UsersEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }
        public bool? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
