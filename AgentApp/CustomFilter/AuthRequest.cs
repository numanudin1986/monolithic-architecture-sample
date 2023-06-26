using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using AgentApp.BusinessOperation.Interfaces;
using AgentApp.DataAccess.Entity;
using Newtonsoft.Json;

namespace AgentApp.CustomFilters
{
    public class AuthRequest : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _getSession = context.HttpContext.Session.GetString("ActiveUser");
            if (_getSession == null)
            {
                context.Result = new RedirectToRouteResult
                (
                new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Account"
                }));
                return;

            }

        }
    }
}
