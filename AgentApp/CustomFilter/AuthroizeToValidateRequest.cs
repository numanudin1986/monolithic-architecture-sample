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

    public class AuthroizeToValidateRequest : Attribute, IAuthorizationFilter
    {
        public readonly IBOUser _bOUser;
        public AuthroizeToValidateRequest(IBOUser  bOUser)
        {
            _bOUser = bOUser;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var _getSession = context.HttpContext.Session.GetString("ActiveUser");
            var _siteUrl = context.HttpContext.Request.Path;
            TblUser logInViewModel = new TblUser();
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
            else
            {
                logInViewModel = JsonConvert.DeserializeObject<TblUser>(_getSession);
            }
            if (!_bOUser.IsAuthorizeRequest(logInViewModel.Id))
            {
                context.Result = new RedirectToRouteResult
                (
                new RouteValueDictionary(new
                {
                    action = "ErrorRequest",
                    controller = "Account"
                }));
                return;
            }
        }

    }
}
