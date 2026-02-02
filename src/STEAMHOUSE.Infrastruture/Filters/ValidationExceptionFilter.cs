using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using STEAMHOUSE.Base.Models;

namespace STEAMHOUSE.Infrastruture.Filters;

public class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FluentValidation.ValidationException ex)
        {
            var errorMessages = string.Join(" | ", ex.Errors.Select(e => e.ErrorMessage));
            
            var result = Result<object>.Failure(errorMessages, 400);

            context.Result = new BadRequestObjectResult(result);
            context.ExceptionHandled = true;
        }
    }
}