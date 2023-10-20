using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Task02.Middleware
{
    public class InterceptorFilterMiddleware
    {
        private readonly RequestDelegate _next;

        public InterceptorFilterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                stopwatch.Stop();
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                // Append custom headers to the response.
                httpContext.Response.Headers.Add("X-Action-Name", httpContext.Request.RouteValues["action"] as string);
                httpContext.Response.Headers.Add("X-HTTP-Method", httpContext.Request.Method);
                httpContext.Response.Headers.Add("X-HTTP-Scheme", httpContext.Request.Scheme);
                httpContext.Response.Headers.Add("X-Host", httpContext.Request.Host.Host);
                httpContext.Response.Headers.Add("X-Port", httpContext.Request.Host.Port.ToString());
                httpContext.Response.Headers.Add("X-Execution-Time", elapsedMilliseconds.ToString());
                httpContext.Response.Headers.Add("X-Server-DateTime", DateTime.Now.ToString());

                return Task.CompletedTask;
            }, context);
            await _next(context);
        }
    }

}
