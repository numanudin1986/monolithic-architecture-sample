using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApp.BusinessOperation.Interfaces;
using AgentApp.BusinessOperation.Operations;
using AgentApp.DataAccess.Entity;
using AgentApp.Helper;
using AgentApp.CustomFilters;

namespace AgentApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBOUser _bOUser;
        public readonly ISessionManager _sesssionManager;

        public AccountController(IBOUser bOUser,  ISessionManager sessionManager)
        {
            _bOUser = bOUser;
            _sesssionManager = sessionManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(TblUser tblUser)
        {
            TblUser _tblData = await _bOUser.Authenticate(tblUser);
            if (_tblData == null)
            {
                ViewBag.UserError = "Email or password is not correct";
            }
            else
            {
                _sesssionManager.SiteUser = _tblData;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Logout()
        {
            _sesssionManager.clearSession();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult ErrorRequest()
        {
            return View();
        }

        //public IActionResult _void()
        //{
        //    return JsonResult
        //}


    }
}
