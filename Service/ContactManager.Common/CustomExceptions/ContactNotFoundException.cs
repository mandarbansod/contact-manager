using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContactManager.Common.CustomExceptions
{
    public class ContactNotFoundException : HttpException
    {
        #region Private Members

        #endregion Private Members

        #region Public Members
        #endregion Public Members

        #region Constructor
        public ContactNotFoundException()
            : base(HttpStatusCode.NotFound, "Contact_Not_Found")
        {

        }
        #endregion Constructor

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
