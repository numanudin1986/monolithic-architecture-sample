using AgentApp.DataAccess.Entity;
using AgentApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentApp.DataAccess.Repositories
{
    public class TblUserRespository : GenericRepository<AgentAppContext, TblUser>, ITblUserRespository
    {
    }

}
