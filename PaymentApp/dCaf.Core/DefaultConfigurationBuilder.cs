using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace dCaf.Core
{
    public static class DefaultConfigurationBuilder
    {
        /// <summary>
        /// Configuratio builder for AspNetCore Web applications
        /// </summary>
        /// <returns></returns>
        public static IConfigurationBuilder ForWeb()
        {
            return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings{(!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")) ? "." : "") }" +
                $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        }

        /// <summary>
        /// Configuration builder for windows service
        /// </summary>
        /// <returns></returns>
        public static IConfigurationBuilder ForWindowsService()
        {
            return new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //windows service project uses DOTNET_ENVIRONMENT as the environment variable
            .AddJsonFile($"appsettings{(!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")) ? "." : "") }" +
                $"{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        }
    }
}
