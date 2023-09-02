using Microsoft.AspNetCore.Mvc.Filters;

namespace AgifyApi.Filters;

public class CORSResourceFilter : IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}