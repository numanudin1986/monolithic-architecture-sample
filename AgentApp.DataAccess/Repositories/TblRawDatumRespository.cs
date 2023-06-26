using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentApp.DataAccess.Interfaces;
using AgentApp.DataAccess.Entity;

namespace AgentApp.DataAccess.Repositories
{
    public class TblRawDatumRespository : GenericRepository<AgentAppContext, TblRawDatum>, ITblRawDatumRespository
    {
    }
}
