using System;
using System.Collections.Generic;
using System.Text;
using AgentApp.DataAccess.Interfaces;
using AgentApp.DataAccess.Entity;

namespace AgentApp.DataAccess.Repositories
{
   public class LoggingRespository : GenericRepository<AgentAppContext, TblLogging>, ILoggingRespository
    {
    }
}
