using System;
using System.Collections.Generic;
using System.Text;

namespace dCaf.Api.Security
{
    public interface IProvideApiKeys
    {
        IEnumerable<ApiKey> GetApiKeys();
    }
}
