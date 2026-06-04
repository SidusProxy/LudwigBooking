namespace Ludwig.Api.Exceptions;

using Ludwig.Api.Exceptions.ExceptionsClasses;
using Microsoft.AspNetCore.Diagnostics;

using Microsoft.AspNetCore.Mvc;



public class GlobalExceptionHandler : IExceptionHandler{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger){
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,CancellationToken cancellationToken){

        _logger.LogError(exception, "Si è verificato un errore non gestito: {Message}", exception.Message);

        var statusCode = StatusCodes.Status500InternalServerError;

        var title = "Internal Server Error";

        var detail = "Si è verificato un errore imprevisto sul server.";

        if (exception is ItemNotFoundException notFoundEx)

        {

            statusCode = StatusCodes.Status404NotFound;

            title = "Resource Not Found";

            detail = notFoundEx.Message;

        }
        else if (exception is IntegrityConditionException intCondEx)
        {

            statusCode = StatusCodes.Status400BadRequest;

            title = "Integrity conditions broken";

            detail = intCondEx.Message;

        }

            httpContext.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails{

            Status = statusCode,

            Title = title,

            Detail = detail,

            Instance = httpContext.Request.Path

        };


        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;

    }

} 


