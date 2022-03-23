
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PaymentApp.Api.App_Start
{
    public static class ApiConfig
    {
        const string _apiKeyHeaderName = "X-API-KEY";
        public static IServiceCollection RegisterApiConfigurations(this IServiceCollection services, string allowSpeficiOrigins, string swaggerDocName, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            // services.AddDcafOrigins(allowSpeficiOrigins, configuration);
            //var options = new SwaggerOptions();
            services.AddControllers(setupAction =>
            {
                setupAction.Filters.Add(new ProducesAttribute("application/json"));
                setupAction.Filters.Add(new ConsumesAttribute("application/json"));
            })
             .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }
            );
            //services.AddDcafOrigins(allowSpeficiOrigins, configuration);

            /*services.AddDcafApiCore(new DcafApiCoreOptions
            {
                SwaggerDocName = swaggerDocName,
                XmlCommentsFilePaths = GetXmlCommentsPath()
            });*/

            return services;
    }

        private static IEnumerable<string> GetXmlCommentsPath()
        {
            var xmlCommentsPathList = new List<string>
            {
                Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"),
            };

            AddXmlFiles(Path.Combine(AppContext.BaseDirectory, $"{typeof(ApiErrorBase).Assembly.GetName().Name}.xml"));
          //  AddXmlFiles(Path.Combine(AppContext.BaseDirectory, $"{typeof(Member).Assembly.GetName().Name}.xml"));

            return xmlCommentsPathList;

            void AddXmlFiles(string dCafXmlCommentsFilePath)
            {
                if (File.Exists(dCafXmlCommentsFilePath))
                {
                    xmlCommentsPathList.Add(dCafXmlCommentsFilePath);
                }
            }
        }
    }
}
