using AgentApp.Components.Helpers;
using AgentApp.BusinessOperation.Interfaces;
using AgentApp.DataAccess.Entity;
using AgentApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgentApp.BusinessOperation.Operations
{
    public class BOUser : IBOUser
    {
        public readonly IGenericRepository<TblUser> _tblUserRespository;

        public BOUser(IGenericRepository<TblUser> tblUserRespository)
        {
            _tblUserRespository = tblUserRespository;
        }
        public async Task<TblUser> Authenticate(TblUser tblUser)
        {
            TblUser _tbl = new TblUser();
            try
            {
                _tbl =  await _tblUserRespository.GetByAsnc(x => x.Email.ToLower().Trim() == tblUser.Email.ToLower().Trim() && x.Password == tblUser.Password);
                
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
            }
            return _tbl;
        }

        public bool IsAuthorizeRequest(int UserId)
        {
            bool IsAuthorize = false;
            try
            {
                IsAuthorize = _tblUserRespository.GetAll().Where(x => x.Id == UserId).Any();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                IsAuthorize = false;
            }
            return IsAuthorize;
        }
    }
}
