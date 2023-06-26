using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentApp.DataAccess.Entity;
namespace AgentApp.BusinessOperation.Interfaces
{
    public interface IBOUser
    {
        Task<TblUser> Authenticate(TblUser tblUser);
        public bool IsAuthorizeRequest(int UserId);
    }
}
