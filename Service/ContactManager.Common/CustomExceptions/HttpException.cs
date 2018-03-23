using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContactManager.Common.CustomExceptions
{
    public class HttpException : Exception
    {
        #region Private Members

        #endregion Private Members

        #region Public Members
        public HttpStatusCode StatusCode { get; set; }
        #endregion Public Members

        #region Constructor
        public HttpException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
        #endregion Constructor

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}