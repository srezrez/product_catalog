using Microsoft.AspNetCore.Mvc.Filters;

namespace product_catalog.API.ExceptionHandling.Contracts;

public interface IExceptionResolver
{
    void OnException(ExceptionContext context);
}
