using LibOwin;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arthman.Middleware
{
    // TODO - share this decl
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public static class CorrelationToken
    {
        public static AppFunc Middleware(AppFunc next)
        {
            return async env =>
            {
                //TODO: improve.  TEST!
                Guid correlationToken;
                var owinContext = new OwinContext(env);
                if (!(owinContext.Request.Headers["Correlation-Token"] != null
                    && Guid.TryParse(owinContext.Request.Headers["Correlation-Token"], out correlationToken)))
                    correlationToken = Guid.NewGuid();

                owinContext.Set("correlationToken", correlationToken.ToString());
                using (LogContext.PushProperty("CorrelationToken", correlationToken))
                    await next(env);
            };
        }
    }
}
