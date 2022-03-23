using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dCaf.Api.Security
{
    /// <summary>
    /// This middleware validates the API Key passed in the header X-ApiKey and optionally validates the origin of the app caller as well.
    /// If the key was validated successfully then a User Identity will be created and added to HttpContext with Username as ApiKey-{Value of the ApiKey}
    /// </summary>
    public class ApiKeyAuthenticatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IProvideApiKeys _apiKeysProvider;
        
        private readonly ILogger<ApiKeyAuthenticatorMiddleware> _logger;
        private const string API_KEY_HEADER_NAME = "X-API-KEY";
        //TODO: Add logger to dependencies?
        public ApiKeyAuthenticatorMiddleware(RequestDelegate next, IProvideApiKeys apiKeysProvider, ILogger<ApiKeyAuthenticatorMiddleware> logger)
        {
            _next = next;
            _apiKeysProvider = apiKeysProvider ?? throw new ArgumentNullException(nameof(apiKeysProvider));
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogDebug(message: "Inside InvokeAsync()");
            string reason = string.Empty;
            bool authorized;
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(authHeader)
                || context.Request.Method == "OPTIONS")
            {
                await _next.Invoke(context);
                return;
            }

            var apiKey = context.Request.Headers[API_KEY_HEADER_NAME].FirstOrDefault();
            var origin = context.Request.Headers["Origin"].FirstOrDefault();
            var _apiKeys = _apiKeysProvider.GetApiKeys();

            var matchingApiKey = _apiKeys.SingleOrDefault(requiredApiKey => (apiKey == requiredApiKey.Key));
            
            if (matchingApiKey == null)
            {
                authorized = false;
                reason = "Matching ApiKey not found.";
            }
            else if(CheckOrigin(matchingApiKey, origin))
            {
                var identity = new GenericIdentity($"ApiKey-{apiKey}");
                context.User = new GenericPrincipal(identity, new[] { _apiKeys.First(key => key.Key == apiKey).Client });

                await _next.Invoke(context);
                return;
            }            
            else
            {
                authorized = false;
                reason = "Origin did not match.";
            }

            if(!authorized)
            {
                _logger.LogWarning(message: $"Invalid API Key. Reason: {reason}. Data:apiKey={apiKey},origin={origin}");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
            }
            return;
        }

        private bool CheckOrigin(ApiKey apiKey, string origin)
        {
            if(apiKey.CheckOrigin == false || string.IsNullOrWhiteSpace(origin))
            {
                return true;
            }

            // if the apikey configuration has "*" in the origin. it means its a wild card search.
            // in case of wild card search convert the * into regular expression pattern (* => .*)
            return apiKey.Origins.Any(x => (x.ToLower().Trim() == origin.Trim().ToLower()) ||
            (x.Contains("*") && Regex.IsMatch(origin.Trim(), WildCardToRegularExpression(x.Trim()), RegexOptions.IgnoreCase)));            
        }

        private string WildCardToRegularExpression(string value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }
    }
}
