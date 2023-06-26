using System;
using System.Collections.Generic;

#nullable disable

namespace MyApp.DataAccess.DataBaseContext
{
    public partial class Order
    {
        public decimal OrdNum { get; set; }
        public decimal OrdAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public DateTime OrdDate { get; set; }
        public string CustCode { get; set; }
        public string AgentCode { get; set; }
        public string OrdDescription { get; set; }

        public virtual Agent AgentCodeNavigation { get; set; }
        public virtual Customer CustCodeNavigation { get; set; }
    }
}
