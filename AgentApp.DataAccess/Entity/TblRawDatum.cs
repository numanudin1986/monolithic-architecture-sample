using System;
using System.Collections.Generic;

#nullable disable

namespace AgentApp.DataAccess.Entity
{
    public partial class TblRawDatum
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
