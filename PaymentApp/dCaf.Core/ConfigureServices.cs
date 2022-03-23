using dCaf.Core.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace dCaf.Core
{
    public static class ConfigureServices
    {
        /// <summary>
        /// Adds CommandQueryService to service collection
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <returns>Reference to service collection instance after the operation has completed</returns>
        public static IServiceCollection ConfigureCoreServices(this IServiceCollection services)
        {
            return services.AddScoped<ICommandQueryService, CommandQueryService>();
        }

        /// <summary>
        /// Adds the UIDGenerationService to service collection
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <returns>Reference to service collection instance after the operation has completed</returns>
        public static IServiceCollection ConfigureUidServices(this IServiceCollection services)
        {
            return services.AddScoped<IUIDGenerationService, UIDGenerationService>();
        }
    }
}
