using AutoMapper;
using PaymentApp.Api.App_Start;
using PaymentApp.Data;
using PaymentApp.Data.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace PaymentApp.Api
{
    public class Startup
    {
        private readonly string allowSpeficiOrigins = "_allowSpecificOrigins";
        private readonly string _swaggerDocName = typeof(Startup).Namespace!;
        const string _apiKeyHeaderName = "X-API-KEY";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Payment App Testing",
                    Version = "v1"

                });
                AddApiKeyAuthorization(c, Configuration);
            });

            services.RegisterApiConfigurations(allowSpeficiOrigins, _swaggerDocName, Configuration);

            services.RegisterEmployeeDbContext(Configuration);
            services.RegisterDependencies(Configuration);
            services.RegisterMemberCommandsAndQueries();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeMapper());

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment App Testing v1");
            });
            //set culture information for requests based on information provided by the client
            app.UseRequestLocalization();

            app.UseCors(allowSpeficiOrigins);

            app.UseRouting();
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Swagger/v1/swagger.json", "Employee API  V1");
            });
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());


            // app.UseDcafApiCore(_swaggerDocName);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void AddApiKeyAuthorization(SwaggerGenOptions swaggerOptions, IConfiguration configuration)
        {
            swaggerOptions.AddSecurityDefinition("ApiKeyInHeader", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = configuration.GetValue<string>(_apiKeyHeaderName),
                Type = SecuritySchemeType.ApiKey
            });
            swaggerOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                In = ParameterLocation.Header,
                                Name = configuration.GetValue<string>(_apiKeyHeaderName),
                                Type = SecuritySchemeType.ApiKey,
                                Reference = new OpenApiReference{Id="ApiKeyInHeader", Type=ReferenceType.SecurityScheme}
                            },
                            new List<string>()
                        }
                    });
        }

    }
}


