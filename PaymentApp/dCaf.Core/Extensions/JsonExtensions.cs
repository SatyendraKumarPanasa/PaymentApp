using Newtonsoft.Json;

namespace dCaf.Core.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this T value, JsonSerializerSettings? serializerSettings = null) where T : class
        {
            if (serializerSettings == null)
                return ToJson(value);

            return JsonConvert.SerializeObject(value, serializerSettings);
        }

        public static string ToJson<T>(this T value) where T : class
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
