using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;
using Arthman.Middleware;

namespace Arthman
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var log = ConfigureLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //            app.UseOwin(x => x.UseNancy());

            app.UseOwin(buildFunc =>
            {
                /*
                buildFunc(next => GlobalErrorLogging.Middleware(next, log));
                buildFunc(next => CorrelationToken.Middleware(next));
                buildFunc(next => RequestLogging.Middleware(next, log));
                buildFunc(next => PerformanceLogging.Middleware(next, log));
                buildFunc(next => new MonitoringMiddleware(next, HealthCheck).Invoke);
                buildFunc.UseNancy(opt => opt.Bootstrapper = new Bootstrapper(log));
                */
                buildFunc(next => CorrelationToken.Middleware(next));
                buildFunc(next => RequestLogging.Middleware(next, log));
                buildFunc.UseNancy();
            });
        }

        private ILogger ConfigureLogger()
        {
            return new LoggerConfiguration()
              .Enrich.FromLogContext()
              .WriteTo.ColoredConsole(
                 LogEventLevel.Verbose,
                 "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
              .CreateLogger();
        }
    }
}
