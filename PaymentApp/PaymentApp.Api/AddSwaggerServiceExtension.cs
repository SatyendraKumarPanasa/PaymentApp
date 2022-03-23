using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace PaymentApp.Api
{
    public static class AddSwaggerServiceExtension
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
            services.AddSwaggerGen(c =>
            {
                c.ExampleFilters();

                c.OperationFilter<AddResponseHeadersFilter>();

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

                // dont add any api security if this property is null
                if (options.ApiSecurities == null)
                {
                    return;
                }

                if (options.ApiSecurities.Any(x => x == ApiSecurity.ApiKey))
                {
                    AddApiKeyAuthorization(c);
                }

                if (options.ApiSecurities.Any(x => x == ApiSecurity.BearerToken))
                {
                    AddBearerTokenAuthorization(c);
                }
            });
            services.AddSwaggerExamplesFromAssemblyOf<ValidationProblemDetailsExample>();
            return services;
        }

        private static void AddApiKeyAuthorization(SwaggerGenOptions swaggerOptions)
        {
            swaggerOptions.AddSecurityDefinition("ApiKeyInHeader", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = _apiKeyHeaderName,
                Type = SecuritySchemeType.ApiKey
            });

            swaggerOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        }

        private static void AddBearerTokenAuthorization(SwaggerGenOptions c)
        {
            c.AddSecurityDefinition("Bearer",
                                    new OpenApiSecurityScheme
                                    {
                                        In = ParameterLocation.Header,
                                        Name = "Authorization",
                                        Type = SecuritySchemeType.ApiKey,
                                        BearerFormat = "JWT",
                                        Scheme = "Bearer"
                                    });


            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                In = ParameterLocation.Header,
                                Name = "Authorization",
                                Type = SecuritySchemeType.ApiKey,
                                Reference = new OpenApiReference{Id="Bearer", Type=ReferenceType.SecurityScheme}
                            },
                            new List<string>()
                        }
                    });
        }
    }
    public class SwaggerOptions
    {

        /// <summary>
        /// A URI-friendly name that uniquely identifies the document
        /// </summary>
        public string? SwaggerDocName { get; set; }

        public OpenApiInfo? OpenApiInfo { get; set; }

        public IEnumerable<string>? XmlCommentsFilePaths { get; set; }

        public IEnumerable<ApiSecurity>? ApiSecurities { get; set; }
        /// <summary>
        /// true if the api versioning has to be implemented in the Swagger
        /// </summary>
        public bool ApiVersioning { get; set; }
    }
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly SwaggerOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, SwaggerOptions options)
        {
            _provider = provider;
            _options = options;
        }

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = _options.OpenApiInfo?.Title,
                Version = description.ApiVersion.ToString(),
                Description = _options.OpenApiInfo?.Description
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
    public enum ApiSecurity
    {
        ApiKey = 0,
        BearerToken = 1
    }
}
