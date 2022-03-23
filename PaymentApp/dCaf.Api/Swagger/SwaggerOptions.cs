using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace dCaf.Api.Swagger
{
    public class SwaggerOptions
    {
        /// <summary>
        /// A URI-friendly name that uniquely identifies the document
        /// </summary>
        public string? SwaggerDocName { get; set; }

        public OpenApiInfo? OpenApiInfo { get; set; }

        public IEnumerable<string>? XmlCommentsFilePaths { get; set; }

        /// <summary>
        /// true if the api versioning has to be implemented in the Swagger
        /// </summary>
        public bool ApiVersioning { get; set; }
    }
}
