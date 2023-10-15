using AutoWrapper.Wrappers;
using BuildingWorks.Common.Exceptions;
using FluentValidation;

namespace BuildingWorksServer.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            _logger.LogError(error, error.Message);

            throw error switch
            {
                EntityNotExistException => new ApiProblemDetailsException("Entity with this id not exist in database", StatusCodes.Status404NotFound),
                ValidationException => HandleValidationException((ValidationException)error),
                _ => new ApiProblemDetailsException("Something went wrong.", StatusCodes.Status500InternalServerError),
            };
        }
        finally
        {
            if (!IsSuccessStatusCode(context.Response.StatusCode))
            {
                throw new ApiProblemDetailsException(context.Response.StatusCode);
            }
        }
    }

    private bool IsSuccessStatusCode(int statusCode)
    {
        return statusCode >= StatusCodes.Status200OK && statusCode <= 299;
    }

    private ApiProblemDetailsException HandleValidationException(ValidationException validationException)
    {
        var errorMessage = string.Join(Environment.NewLine, validationException.Errors.Select(error => error.ErrorMessage));

        if (string.IsNullOrWhiteSpace(errorMessage))
        {
            errorMessage = validationException.Message;
        }

        return new ApiProblemDetailsException(errorMessage, StatusCodes.Status400BadRequest);
    }
}
