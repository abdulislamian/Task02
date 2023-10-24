using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Task02.Middleware
{
    public class InterceptHttpResponseMiddleware: ActionFilterAttribute
    {
        private Stopwatch stopwatch;
        public InterceptHttpResponseMiddleware()
        {
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            context.HttpContext.Response.Headers.Add("Action-Name", context.RouteData.Values["action"] as string);
            context.HttpContext.Response.Headers.Add("HTTP-Method", context.HttpContext.Request.Method);
            context.HttpContext.Response.Headers.Add("HTTP-Scheme", context.HttpContext.Request.Scheme);
            context.HttpContext.Response.Headers.Add("Host",    context.HttpContext.Request.Host.Host);
            context.HttpContext.Response.Headers.Add("Port", context.HttpContext.Request.Host.Port.ToString());
            context.HttpContext.Response.Headers.Add("Execution-Time", elapsedMilliseconds.ToString());
            context.HttpContext.Response.Headers.Add("Server-DateTime", DateTime.Now.ToString());

            base.OnActionExecuted(context);
        }
    }
}
