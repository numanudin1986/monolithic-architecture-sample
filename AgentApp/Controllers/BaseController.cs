using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentApp.Common;
using System.Security.Claims;
using AgentApp.DataAccess.Entity;
using Newtonsoft.Json;
using AgentApp.Helper;

namespace AgentApp.Controllers
{
    public struct Role
    {
        public const string Admin = "Admin";
        public const string Guest = "Guest";
    }
    public class BaseController : Controller
    {
        public readonly SessionManager _sesssionManager;
        public BaseController(SessionManager sessionManager)
        {
            _sesssionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
