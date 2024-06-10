using Microsoft.AspNetCore.Mvc.Filters;
using product_catalog.API.ExceptionHandling.Contracts;

namespace product_catalog.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var globalResolver = context.HttpContext.RequestServices.GetRequiredService<IExceptionResolver>();
        globalResolver.OnException(context);
    }
}
