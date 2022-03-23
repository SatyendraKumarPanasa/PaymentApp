using System;
using System.Collections.Generic;

namespace dCaf.Api.Security
{
    public class ApiKey
    {
        public string? Key { get; set; }
        public string? Client { get; set; }
        public bool CheckOrigin { get; set; }
        public IList<string>? Origins { get; set; }
        public IList<string>? Claims { get; set; }
    }
}
