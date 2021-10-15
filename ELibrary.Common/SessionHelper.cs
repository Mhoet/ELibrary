using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ELibrary.Common
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetObjectAsJson(key, value);
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.Keys.ToString();
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}