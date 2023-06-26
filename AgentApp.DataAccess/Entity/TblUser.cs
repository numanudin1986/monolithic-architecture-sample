using System;
using System.Collections.Generic;

#nullable disable

namespace AgentApp.DataAccess.Entity
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public int? UserRoleId { get; set; }
    }
}
