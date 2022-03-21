using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Microservices.Requests.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = GetResult(context.Exception);
        }

        private IActionResult GetResult(Exception exception)
        {
            var result = new JsonResult(new { Erro = exception?.InnerException?.Message ?? exception?.Message, exception?.StackTrace }) { StatusCode = 500 };
            return result;
        }
    }
}
