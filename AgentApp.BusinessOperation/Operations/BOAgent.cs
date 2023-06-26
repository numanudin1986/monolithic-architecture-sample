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
using System.Globalization;

namespace AgentApp.BusinessOperation.Operations
{
    public class BOAgent : IBOAgent
    {
        IGenericRepository<TblRawDatum> _ITblRawDatumRespository;
        IGenericRepository<AgentRecord> _agentRecordRepository;
        public BOAgent(IGenericRepository<TblRawDatum> tblRawDatumRespository, IGenericRepository<AgentRecord> agentRecordRepository)
        {
            _ITblRawDatumRespository = tblRawDatumRespository;
            _agentRecordRepository = agentRecordRepository;
        }
        public object LoadAllAgents(HttpRequest Request)
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var jsonstr = Request.Form["columns[0][search][value]"].FirstOrDefault();

            var obj = JsonConvert.DeserializeObject<AgentRecordDTO>(jsonstr);
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var _objAgent = GetAllAgents();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                // userData = userData.OrderBy(s => sortColumn + " " + sortColumnDirection);
            }
            if (obj != null)
            {
                if (!string.IsNullOrEmpty(obj.AgentName))
                    _objAgent = _objAgent.Where(x => (x.AgentName ?? string.Empty).ToLower().Trim().Contains((obj.AgentName ?? string.Empty).ToLower().Trim()));
                if (!string.IsNullOrEmpty(obj.WorkingArea))
                    _objAgent = _objAgent.Where(x => (x.WorkingArea ?? string.Empty).ToLower().Trim().Contains((obj.WorkingArea ?? string.Empty).ToLower().Trim()));
                if (!string.IsNullOrEmpty(obj.Commission))
                    _objAgent = _objAgent.Where(x => (x.Commission ?? string.Empty).ToLower().Trim().Contains((obj.Commission ?? string.Empty).ToLower().Trim()));
                if (!string.IsNullOrEmpty(obj.PhoneNo))
                    _objAgent = _objAgent.Where(x => (x.PhoneNo ?? string.Empty).ToLower().Trim().Contains((obj.PhoneNo ?? string.Empty).ToLower().Trim()));
                if (!string.IsNullOrEmpty(obj.Country))
                    _objAgent = _objAgent.Where(x => (x.Country ?? string.Empty).ToLower().Trim().Contains((obj.Country ?? string.Empty).ToLower().Trim()));
            }
            recordsTotal = _objAgent.Count();
            List<AgentRecordDTO> _lstAllAgent = _objAgent.Skip(skip).Take(pageSize).ToList();
            _lstAllAgent.ForEach(x =>
            {
                x.Edit = "<a href='/Agent/AddAgent?Inkey=" + SecurityEncryption.EncryptNumber(Convert.ToString(x.Id)) + "' style='color:white' class='btnEdit btn btn-primary'><i class='fa fa-edit'></i> <span>Edit</span></a>";
                x.Delete = "<button class='btn btn-danger js-sweetalert' data-type='confirm'><i class='fa fa-trash-o'></i> <span>Delete</span></button>";
            });
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = _lstAllAgent };
            return jsonData;
        }
        public IQueryable<AgentRecordDTO> GetAllAgents()
        {
            try
            {
                return _agentRecordRepository.GetAllQueryable().Select(x => new AgentRecordDTO { AgentName = x.AgentName, Commission = x.Commission, Country = x.Country, PhoneNo = x.PhoneNo, WorkingArea = x.WorkingArea, Id = x.Id });
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        public async Task<Common> AddAgent(AgentRecordDTO agentRecord)
        {
            Common common = new Common();
            try
            {
                if (string.IsNullOrEmpty(agentRecord.EncryptedAgentId))
                {
                    AgentRecord _agentSave = MapData(agentRecord);
                    _agentRecordRepository.Add(_agentSave);
                    await _agentRecordRepository.SaveAsyn();
                    common.statusMessage = "Agent has been saved successfully!";
                    common.statusCode = 200;
                }
                else
                {
                    int _agentId = Convert.ToInt32(SecurityEncryption.DecryptNumber(agentRecord.EncryptedAgentId));
                    AgentRecord _objagent = _agentRecordRepository.GetBy(x => x.Id == _agentId).FirstOrDefault();
                    if (_objagent != null)
                    {
                        _objagent.AgentName = agentRecord.AgentName;
                        _objagent.WorkingArea = agentRecord.WorkingArea;
                        _objagent.Commission = agentRecord.Commission;
                        _objagent.PhoneNo = agentRecord.PhoneNo;
                        _objagent.Country = agentRecord.Country;
                        _agentRecordRepository.Edit(_objagent);
                        await _agentRecordRepository.SaveAsyn();
                        common.statusMessage = "Insurance has been updated successfully!";
                        common.statusCode = 200;
                    }
                    else
                    {
                        common.statusCode = 404;
                        common.statusMessage = "Something went wrong, please contect support!";
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                common.statusCode = 500;
                common.statusMessage = "Something went wrong, please contect support!";
            }
            return common;
        }

        public AgentRecordDTO GetData(string Id)
        {
            AgentRecordDTO agentRecord = new AgentRecordDTO();
            try
            {
                var _fetchRecord = _agentRecordRepository.GetBy(x => x.Id == Convert.ToInt32(SecurityEncryption.DecryptNumber(Id.Trim()))).Select(x => new AgentRecordDTO { AgentName = x.AgentName, Commission = x.Commission, PhoneNo = x.PhoneNo, Country = x.Country, WorkingArea = x.WorkingArea }).FirstOrDefault();
                return _fetchRecord == null ? agentRecord : _fetchRecord;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return agentRecord;
            }
            ///throw new NotImplementedException();
        }

        public async Task<Common> DeleteAgentRecord(AgentRecordDTO agentRecord)
        {
            Common _objCommon = new Common();
            try
            {
                AgentRecord agent = MapData(agentRecord);
                _agentRecordRepository.Delete(agent);
                await _agentRecordRepository.SaveAsyn();
                _objCommon.statusCode = 200;
                _objCommon.statusMessage = "Insurance has been deleted successfully";
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                _objCommon.statusCode = 500;
                _objCommon.statusMessage = "Something went wrong, please contect support!";
            }
            return _objCommon;
        }
        public AgentRecord MapData(AgentRecordDTO agentRecordDTO)
        {
            AgentRecord agent = new AgentRecord
            {
                AgentName = agentRecordDTO.AgentName,
                WorkingArea = agentRecordDTO.WorkingArea,
                Country = agentRecordDTO.Country,
                Commission = agentRecordDTO.Commission,
                PhoneNo = agentRecordDTO.PhoneNo
            };
            return agent;
        }

        public Common LoadLineGraph()
        {
            Common _common = new Common();
            List<LineGraphDTO> _lstMonths = new List<LineGraphDTO>();
            try
            {
                var getData = _agentRecordRepository.GetAll();
                int _lenMonth = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames.Length;
                for (int i = 0; i < _lenMonth; i++)
                {
                    string _monthName = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i];
                    int getCount = getData.Where(x => x.CreatedDated != null && x.CreatedDated.Value.ToString("MMMM") == _monthName).Count();
                    if (getCount > 0)
                    {
                        _lstMonths.Add(new LineGraphDTO
                        {
                            Month = _monthName,
                            Count = getCount
                        });
                    }
                }
                _common.statusCode = 200;
                _common.object1 = _lstMonths;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                _common.statusCode = 300;
                _common.ErrorMessage = "Line Graph Not Load Something went wrong.";
            }
            return _common;
            //throw new NotImplementedException();
        }
    }
}
