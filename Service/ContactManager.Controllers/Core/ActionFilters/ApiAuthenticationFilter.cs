using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Controllers.Core.ActionFilters
{
    public class ApiAuthenticationFilter : IAuthorizationFilter
    {
        #region Private Members

        #endregion Private Members

        #region Constructor

        #endregion Constructor

        #region Public Methods
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
        }
        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods

    }
}
