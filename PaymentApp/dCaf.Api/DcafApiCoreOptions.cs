using dCaf.Api.Security;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;

namespace dCaf.Api
{
    public class DcafApiCoreOptions
    {
        //commenting this code temporarily. will uncomment this code when oAuth2 is supported
        //public JwtBearerOptions JwtBearerOptions { get; set; } = new JwtBearerOptions
        //{
        //    RequireHttpsMetadata = false
        //};

        public string? SwaggerDocName { get; set; }

        public IEnumerable<string>? XmlCommentsFilePaths { get; set; }

        public bool ApiVersioning { get; set; }
    }
}