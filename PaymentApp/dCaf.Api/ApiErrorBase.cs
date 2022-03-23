using System;

namespace dCaf.Api
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
