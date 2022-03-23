using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace dCaf.Api.Security
{
    public class AppSettingsApiKeyProvider : IProvideApiKeys
    {
        private readonly IEnumerable<ApiKey> apiKeysConfigs;

        public AppSettingsApiKeyProvider(IOptions<List<ApiKey>> apiKeysConfigOptions)
        {
            this.apiKeysConfigs = apiKeysConfigOptions?.Value ?? throw new ArgumentNullException(nameof(apiKeysConfigOptions));
        }

        public IEnumerable<ApiKey> GetApiKeys()
        {
            return apiKeysConfigs;
        }
    }
}
