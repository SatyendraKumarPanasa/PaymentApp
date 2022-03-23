using dCaf.Api.Security;
using dCaf.Api.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace dCaf.Api
{
    public static class DcafApiCoreServiceExtension
    {
        private const string _apiKeys = "ApiKeys";
        public static IServiceCollection AddDcafApiCore(this IServiceCollection services, DcafApiCoreOptions options)
        {
            //commenting this code temporarily. will uncomment this code when oAuth2 is supported
            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", jbo => {
            //        jbo = options.JwtBearerOptions;
            //    });

            services.AddDcafSwagger(new SwaggerOptions
            {
                SwaggerDocName = options.SwaggerDocName,
                OpenApiInfo = new OpenApiInfo
                {
                    Title = options.SwaggerDocName,
                    //Version = "v1"
                },
                XmlCommentsFilePaths = options.XmlCommentsFilePaths,
                ApiVersioning = options.ApiVersioning
            });

            services.AddHealthChecks();

            return services;
        }

        public static IServiceCollection AddDcafOrigins(this IServiceCollection services, string allowSpeficiOrigins,
                                                        IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<List<ApiKey>>(configuration.GetSection(_apiKeys));

            var origins = GetOriginsFromConfig(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(allowSpeficiOrigins,
                builder =>
                {
                    builder.WithOrigins(origins)
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            return services;
        }
        public static IMvcBuilder SetValidationProblemDetail(this IMvcBuilder mvcBuilder, string? validationProblem = null)
        {
            mvcBuilder.ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = string.IsNullOrWhiteSpace(validationProblem) ? "https://httpstatuses.com/422" : validationProblem,
                        Title = "One or more model validation errors occurred.",
                        Status = StatusCodes.Status422UnprocessableEntity,
                        Detail = "See the errors property for details.",
                        Instance = context.HttpContext.Request.Path
                    };

                    problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                    return new UnprocessableEntityObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });

            return mvcBuilder;
        }

        private static string[] GetOriginsFromConfig(IConfiguration configuration)
        {
            var apiKeys = new List<ApiKey>();
            configuration.GetSection(_apiKeys).Bind(apiKeys);
            var origins = apiKeys.SelectMany(x => x.Origins).ToArray();
            return origins;
        }
    }
}
