using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Controllers.Core.Results
{
    public class HttpExceptionResult : IActionResult
    {
        private HttpStatusCode _statusCode { get; set; }
        private string _message { get; set; }

        protected HttpExceptionResult(HttpStatusCode statusCode, string message)
        {
            _statusCode = statusCode;
            _message = message;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_message)
            {
                StatusCode = (int)_statusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
