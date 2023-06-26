using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgentApp.DataAccess
{
   public class Common
    {
        [NotMapped]
        public string Edit { get; set; }
        [NotMapped]
        public string Delete { get; set; }

    }
}
