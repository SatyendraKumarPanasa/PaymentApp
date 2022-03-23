using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dCaf.Api
{
    public static class DcafApiCoreExceptionExtension
    {
        public static IApplicationBuilder UseDcafApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DcafApiCoreExceptionMiddleware>();
        }
    }
}
