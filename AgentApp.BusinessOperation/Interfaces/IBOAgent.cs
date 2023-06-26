using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AgentApp.DataAccess.Entity;
using AgentApp.Components.Helpers;
using AgentApp.DTO.CustomDTO;

namespace AgentApp.BusinessOperation.Interfaces
{
    public interface IBOAgent
    {
        Task<Common> AddAgent(AgentRecordDTO agentRecord);
        object LoadAllAgents(HttpRequest Request);

        AgentRecordDTO GetData(string Id);
        Task<Common> DeleteAgentRecord(AgentRecordDTO agentRecord);
        Common LoadLineGraph();
        //object 
    }

}
