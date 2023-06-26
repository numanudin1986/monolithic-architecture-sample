using System;
using System.Collections.Generic;

#nullable disable

namespace MyApp.DataAccess.DataBaseContext
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string CustCity { get; set; }
        public string WorkingArea { get; set; }
        public string CustCountry { get; set; }
        public decimal? Grade { get; set; }
        public decimal OpeningAmt { get; set; }
        public decimal ReceiveAmt { get; set; }
        public decimal PaymentAmt { get; set; }
        public decimal OutstandingAmt { get; set; }
        public string PhoneNo { get; set; }
        public string AgentCode { get; set; }

        public virtual Agent AgentCodeNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
