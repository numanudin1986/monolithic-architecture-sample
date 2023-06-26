using System;
using System.Collections.Generic;

#nullable disable

namespace AgentApp.DataAccess.Entity
{
    public partial class TblLogging
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string DebugMessage { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string LineNumber { get; set; }
        public string MehtodName { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
