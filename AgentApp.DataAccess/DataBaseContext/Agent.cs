using System;
using System.Collections.Generic;

#nullable disable

namespace MyApp.DataAccess.DataBaseContext
{
    public partial class Agent
    {
        public Agent()
        {
            Customers = new HashSet<Customer>();
            Orders = new HashSet<Order>();
        }

        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string WorkingArea { get; set; }
        public decimal? Commission { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
