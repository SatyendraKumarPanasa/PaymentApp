using System;

namespace dCaf.Api
{
    public class ApiError : ApiErrorBase
    {

        /// <summary>
        /// Exception is usually not exposed except for special scenarios
        /// </summary>
        public Exception? Exception { get; set; }
    }
}
