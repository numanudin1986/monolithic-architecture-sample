using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentApp.Common;
using System.Security.Claims;
using AgentApp.DataAccess.Entity;
using Newtonsoft.Json;
using AgentApp.Helper;

namespace AgentApp.Helper
{
    public struct Role
    {
        public const string Admin = "Admin";
        public const string Guest = "Guest";
    }

    public interface ISessionManager
    {
        TblUser SiteUser { get; set; }

        void clearSession();
        Task CreateAuthenticationTicket(TblUser user);
    }

    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public TblUser SiteUser //Get Site User
        {
            set
            {

                var _stringObject = JsonConvert.SerializeObject(value);
                _contextAccessor.HttpContext.Session.SetString("ActiveUser", _stringObject);
            }
            get
            {
                var _getSession = _contextAccessor.HttpContext.Session.GetString("ActiveUser");
                TblUser logInViewModel = JsonConvert.DeserializeObject<TblUser>(_getSession);
                return logInViewModel;
            }
        }
        public async Task CreateAuthenticationTicket(TblUser user)
        {
            var key = Encoding.ASCII.GetBytes(SiteKeys.Token);
            var JWToken = new JwtSecurityToken(
            issuer: SiteKeys.WebSiteDomain,
            audience: SiteKeys.WebSiteDomain,
            claims: GetUserClaims(user),
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            _contextAccessor.HttpContext.Session.SetString("JWToken", token);
            SiteUser = user;
        }
        private IEnumerable<Claim> GetUserClaims(TblUser user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.Email);
            claims.Add(_claim);

            _claim = new Claim("Role", Role.Admin);
            claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }




        public void clearSession()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }
    }

}
