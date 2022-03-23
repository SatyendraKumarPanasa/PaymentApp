using Microsoft.AspNetCore.Builder;

namespace dCaf.Api.Security
{
    public static class ApiKeyAuthenticatorMiddlewareExtension
    {
        public static IApplicationBuilder UseApiKeyAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyAuthenticatorMiddleware>();
        }
    }
}
