using dCaf.Api.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;

namespace dCaf.Api
{
    public static class DcafApiCoreConfigurationExtension
    {
        public static IApplicationBuilder UseDcafApiCore(this IApplicationBuilder app, string swaggerDocName)
        {
            UseInternalDcafApiCore(app, swaggerDocName);
            return app;
        }
        public static IApplicationBuilder UseDcafApiCore(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            UseInternalDcafApiCore(app, provider: provider);           
            return app;
        }
        private static void UseInternalDcafApiCore(IApplicationBuilder app, string? swaggerDocName = null, IApiVersionDescriptionProvider? provider = null)
        {
            app.UseDcafApiExceptionHandler();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            if (!string.IsNullOrWhiteSpace(swaggerDocName))
            {
                app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"swagger/{swaggerDocName}/swagger.json", swaggerDocName);
                c.RoutePrefix = string.Empty;
                });
            }
            else if (provider != null)
            {
                app.UseSwaggerUI(
                    options =>
                    {
                    foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                            options.RoutePrefix = string.Empty;
                        }
                    });
            }
            app.UseSerilogRequestLogging()
            .UseApiKeyAuthentication()
            .UseAuthentication()
            ;
        }

        /// <summary>
        /// Adds health check endpoint to the Microsoft.AspNetCore.Routing.EndpointRoutingMiddleware middleware. 
        /// Health check can be accessed using <b>/infrastructure/health</b> endpoint
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        /// <returns></returns>
        public static IApplicationBuilder UseDcafHealthChecks(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
            });

            return appBuilder;
        }
    }
}
