using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AgentApp.DataAccess.Entity;

namespace AgentApp.BusinessOperation.Interfaces
{
    public interface IBOStudent
    {
        Task AddTblPatient(TblRawDatum tblRawDatum);

    }
}
