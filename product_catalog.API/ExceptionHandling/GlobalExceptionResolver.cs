using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using product_catalog.API.ExceptionHandling.Contracts;
using product_catalog.API.Responses;

namespace product_catalog.API.ExceptionHandling;

public class GlobalExceptionResolver : IExceptionResolver
{
    private readonly ILogger _logger;

    public GlobalExceptionResolver(ILogger<GlobalExceptionResolver> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var errorResponse = new ErrorResponse
        (
            ErrorMessage: exception.Message
        );
        _logger.LogError(exception, exception.Message);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
