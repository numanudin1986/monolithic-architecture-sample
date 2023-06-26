using System;
using System.Collections.Generic;

#nullable disable

namespace AgentApp.DataAccess.Entity
{
    public partial class AgentRecord
    {
        public int Id { get; set; }
        public string AgentName { get; set; }
        public string WorkingArea { get; set; }
        public string Commission { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }
        public DateTime? CreatedDated { get; set; }
    }
}
