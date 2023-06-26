using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApp.DataAccess.Entity;
using AgentApp.BusinessOperation.Interfaces;
using AgentApp.CustomFilters;
using System.Web.Http.Description;
using AgentApp.DTO.CustomDTO;
namespace AgentApp.Controllers
{
    [AuthRequest]

    public class AgentController : Controller
    {
        public readonly IBOAgent _bOAgent;
        public AgentController(IBOAgent bOAgent)
        {
            _bOAgent = bOAgent;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoadAgentData()
        {
            try
            {
                var jsonData = _bOAgent.LoadAllAgents(Request);
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult AddAgent(string Inkey)
        {
            ViewBag.AgentId = string.IsNullOrEmpty(Inkey) ? string.Empty : Inkey;
            return View(_bOAgent.GetData(Inkey));
        }

        [HttpPost]
        //[ResponseType(typeof(AgentRecordDTO))]
        public async Task<JsonResult> AddAgent(AgentRecordDTO agentRecord)
        {
            dynamic data = string.Empty;
            if (ModelState.IsValid)
                data = await _bOAgent.AddAgent(agentRecord);
            return Json(data);
        }
        [HttpPost]
        //[ResponseType(typeof(AgentRecordDTO))]
        public async Task<JsonResult> DeleteAgent(AgentRecordDTO agentRecord)
        {
            dynamic data = string.Empty;
            await _bOAgent.DeleteAgentRecord(agentRecord);
            return Json(data);
        }
        [HttpPost]
        public JsonResult LoadAgentLineGraph()
        {
            dynamic data = _bOAgent.LoadLineGraph();
            return Json(data);
        }
    }
}
