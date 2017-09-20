using System;
using System.Collections.Generic;
using LibOwin;
using System.Threading.Tasks;
using Serilog;

namespace Arthman.Middleware
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public static class RequestLogging
    {
        public static AppFunc Middleware(AppFunc next, ILogger log)
        {
            return async env =>
            {
                var owinContext = new OwinContext(env);
                log.Information(
                  "Incoming request: {@Method}, {@Path}, {@Headers}",
                  owinContext.Request.Method,
                  owinContext.Request.Path,
                  owinContext.Request.Headers);
                await next(env);
                log.Information(
                  "Outgoing response: {@StatucCode}, {@Headers}",
                   owinContext.Response.StatusCode,
                   owinContext.Response.Headers);
            };
        }
    }
}
