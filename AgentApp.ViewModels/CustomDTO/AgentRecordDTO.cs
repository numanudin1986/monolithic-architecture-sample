using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentApp.DTO.CustomDTO
{
   public class AgentRecordDTO : CommonDTO
    {
        public int Id { get; set; }
        public string AgentName { get; set; }
        public string WorkingArea { get; set; }
        public string Commission { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }
        public string EncryptedAgentId { get; set; }

    }
}
