namespace dCaf.Core
{
    public class CareingtonContext
    {
        /// <summary>
        /// UserName is a non-nullable field with default value as "anonymous@careington.com" which can be overriden by the consumers
        /// </summary>
        public string UserName { get; set; } = "anonymous@careington.com";

        /// <summary>
        /// IsAuthenticated should be set to true if the request is authenticated
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// CorrelationId is a unique identifier attached to the requests and is propagated in to the subsequent requests or messages
        /// </summary>
        public string? CorrelationId { get; set; }
    }
}
