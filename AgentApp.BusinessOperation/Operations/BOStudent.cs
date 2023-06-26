using AgentApp.Components.Helpers;
using AgentApp.BusinessOperation.Interfaces;
using AgentApp.DataAccess.Entity;
using AgentApp.DataAccess.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AgentApp.DTO.CustomDTO;

namespace AgentApp.BusinessOperation.Operations
{
    public class BOStudent : IBOStudent
    {
        IGenericRepository<TblRawDatum> _ITblRawDatumRespository;
        IGenericRepository<AgentRecord> _agentRecordRepository;
        public BOStudent(IGenericRepository<TblRawDatum> tblRawDatumRespository, IGenericRepository<AgentRecord> agentRecordRepository)
        {
            _ITblRawDatumRespository = tblRawDatumRespository;
            _agentRecordRepository = agentRecordRepository;
        }

        public async Task AddTblPatient(TblRawDatum tblRawDatum)
        {
            try
            {
                _ITblRawDatumRespository.Add(tblRawDatum);
                await _ITblRawDatumRespository.SaveAsyn();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
            }
        }

      
      
    }
}
