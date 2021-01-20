using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using ApplicationException = Application.Common.Exceptions.ApplicationException;

namespace WebAPI.Common
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            string result;

            if (exception is ApplicationException applicationException)
            {
                code = applicationException.StatusCode;
                result = JsonConvert.SerializeObject(new ErrorResponse(applicationException));
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                result = JsonConvert.SerializeObject(new ErrorResponse("500", "Internal Server Error."));
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }

    class ErrorResponse
    {
        public string ErrorCode { get; }
        public string ErrorMessage { get; }

        public ErrorResponse(ApplicationException exception)
        {
            ErrorCode = exception.ResultStatus.ToString();
            ErrorMessage = "todo";
        }

        public ErrorResponse(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}