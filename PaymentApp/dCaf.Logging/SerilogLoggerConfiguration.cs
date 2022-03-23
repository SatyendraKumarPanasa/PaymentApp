using dCaf.Logging.Enrichers;
using Destructurama;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;
using System;
using System.Diagnostics;

namespace dCaf.Logging
{
    public static class SerilogLoggerConfiguration
    {
        public static LoggerConfiguration Get(IConfiguration configuration)
        {
            Activity.ForceDefaultIdFormat = true;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Information);

            return new LoggerConfiguration()
                .Destructure.UsingAttributes()
                .MinimumLevel.ControlledBy(levelSwitch)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.With<ApplicationNameEnricher>()
                .WriteTo.File(new RenderedCompactJsonFormatter()
                    , Environment.GetEnvironmentVariable("LOG_PATH")
                        ?? configuration.GetValue<string>("dCaf:Serilog:LogPath")
                    , rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, fileSizeLimitBytes: 10000000)
                .ReadFrom.Configuration(configuration) //add any additional configuration or sink from App specific configuration
            ;
        }
    }
}
