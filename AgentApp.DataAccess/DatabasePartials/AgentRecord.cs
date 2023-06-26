using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentApp.DataAccess.Entity
{
    //class TblUser
    //{
    //}
    [MetadataType(typeof(AgentRecordMetaData))]
    public partial class AgentRecord : Common
    {
        [NotMapped]
        public string EncryptedAgentId { get; set; }
    }
    internal sealed class AgentRecordMetaData
    {

    }
}
