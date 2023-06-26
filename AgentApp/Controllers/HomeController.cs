using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgentApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgentApp.BusinessOperation.Interfaces;
using AgentApp.DataAccess.Entity;
using AgentApp.CustomFilters;

namespace AgentApp.Controllers
{
    [AuthRequest]

    public class HomeController : Controller
    {
        private readonly IBOStudent _bOStudent;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBOStudent bOStudent)
        {
            _logger = logger;
            _bOStudent = bOStudent;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent()
        {
            TblRawDatum tblRawDatum = new TblRawDatum
            {
                FirstName = "Test",
                Email = "Test@gmail.com",
                LastName = "Test 2"
            };
            if (ModelState.IsValid)
                await _bOStudent.AddTblPatient(tblRawDatum);
            return View();
        }
    }
}
