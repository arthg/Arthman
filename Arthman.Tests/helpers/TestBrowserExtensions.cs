using System;
using System.Collections.Generic;
using System.IO;
using Nancy.Testing;
using Newtonsoft.Json;

namespace Arthman.Tests.helpers
{
    public static class TestBrowserExtensions
    {
        public static TModel BodyAsJson<TModel>(this BrowserResponse response)
        {
            if (!response.ContentType.Contains("application/json"))
            {
                throw new ArgumentException("Not json body.");
            }
            var json = response.Body.AsString();
            var settings = new JsonSerializerSettings();
            return JsonConvert.DeserializeObject<TModel>(json, settings);
        }

        public static dynamic BodyAsDynamic(this BrowserResponse response)
        {
            return response.BodyAsJson<dynamic>();
        }

        public static byte[] BodyAsBytes(this BrowserResponse response)
        {
            var responseStream = new MemoryStream();
            response.Context.Response.Contents(responseStream);
            return responseStream.ToArray();
        }

        public static BrowserContext QueryString(this BrowserContext context, string key, string value)
        {
            context.Query(key, value);
            return context;
        }

        public static BrowserContext Query(this BrowserContext context, IEnumerable<KeyValuePair<string, string>> queryValues)
        {
            foreach (var queryValue in queryValues)
            {
                context.Query(queryValue.Key, queryValue.Value);
            }
            return context;
        }

        public static BrowserContext HttpsBrowserContext(this BrowserContext context)
        {
            context.HttpsRequest();
            return context;
        }

        public static BrowserContext JsonBrowserContext(this BrowserContext context, object request)
        {
            context.Body(JsonConvert.SerializeObject(request));
            context.Header("Content-Type", "application/json");
            return context;
        }

        public static BrowserContext ApiAuthToken(this BrowserContext context, string token)
        {
            context.Header("Authorization", "Token " + token);
            return context;
        }
    }
}
