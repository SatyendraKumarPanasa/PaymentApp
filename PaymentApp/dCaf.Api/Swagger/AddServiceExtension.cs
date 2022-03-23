using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace dCaf.Api.Swagger
{
    public static class AddServiceExtension
    {
        const string _apiKeyHeaderName = "X-API-KEY";
        public static IServiceCollection AddDcafSwagger(this IServiceCollection services, SwaggerOptions options)
        {
            if (options.ApiVersioning)
            {
                services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
                services.AddSingleton<SwaggerOptions>();
                services.AddTransient<IConfigureOptions<SwaggerGenOptions>>(
                    x => { return new ConfigureSwaggerOptions(x.GetRequiredService<IApiVersionDescriptionProvider>(), options); }
                    );
            }

            // Register the Swagger generator, defining 1 or more Swagger documents
            return services.AddSwaggerGen(c =>
            {
                if (options.ApiVersioning == false)
                {
                    c.SwaggerDoc(options.SwaggerDocName, options.OpenApiInfo);
                }

                if (options.XmlCommentsFilePaths != null)
                {
                    foreach (var xmlCommentsFilePath in options.XmlCommentsFilePaths)
                    {
                        c.IncludeXmlComments(xmlCommentsFilePath);
                    }
                }

                c.AddSecurityDefinition("ApiKeyInHeader", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = _apiKeyHeaderName,
                    Type = SecuritySchemeType.ApiKey
                });
                //c.AddSecurityDefinition("IdentityServer4", 
                //    new OpenApiSecurityScheme
                //    {
                //        In = ParameterLocation.Header,
                //        Name = "Authorization",
                //        Type = SecuritySchemeType.OpenIdConnect
                //    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Name = _apiKeyHeaderName,
                            Type = SecuritySchemeType.ApiKey,
                            Reference = new OpenApiReference{Id="ApiKeyInHeader", Type=ReferenceType.SecurityScheme}
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
