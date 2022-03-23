using System;
using System.Text;

namespace dCaf.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}
