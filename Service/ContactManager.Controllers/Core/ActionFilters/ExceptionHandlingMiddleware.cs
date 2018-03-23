using ContactManager.Common.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Controllers.Core
{
    public class ExceptionHandlingMiddleware
    {
        #region Private Memebers
        private readonly RequestDelegate next;
        #endregion Private Members

        #region Constructor
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        #endregion Constructor 

        #region Public Methods
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        #endregion Public Methods

        #region Private Methods
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)GetHttpStatusCode(exception);
            return context.Response.WriteAsync(result);
        }

        private static HttpStatusCode GetHttpStatusCode(Exception exception)
        {
            if (exception is HttpException)
            {
                return (exception as HttpException).StatusCode;
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
        #endregion Private Methods
    }
}
