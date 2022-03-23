using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Api
{
    public class ApiErrorBase
    {
        /// <summary>
        /// User friendly error message with an unique id
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// unique id to check in error logs
        /// </summary>
        public string? ExceptionId { get; set; }
    }
}
