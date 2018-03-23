using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContactManager.Controllers.Core.Results
{
    public class InternalServerErrorObjectResult : ActionResult
    {
        /// <summary>Gets or sets the HTTP status code.</summary>
        public int StatusCode { get; set; } = 500;

        /// <summary>Gets or sets the value to be formatted.</summary>
        public object Value { get; set; }

        /// <summary>
        /// Creates a new <see cref="T:Microsoft.AspNetCore.Mvc.JsonResult" /> with the given <paramref name="value" />.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        public InternalServerErrorObjectResult(object value)
        {
            this.Value = value;
        }

        private string Serialize<T>(T value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var type = value.GetType();
            XmlSerializer serializer = new XmlSerializer(type);

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, value);
                return writer.ToString();
            }
        }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/xml";
            response.StatusCode = StatusCode;
            var xmlBytes = Encoding.ASCII.GetBytes(Serialize(Value));
            context.HttpContext.Response.Body.WriteAsync(xmlBytes, 0, xmlBytes.Length);
            return Task.CompletedTask;
        }
    }
}