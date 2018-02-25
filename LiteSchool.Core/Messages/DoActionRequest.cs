using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.Messages
{
    [DataContract()]
    public class DoActionRequest : BaseRequest
    {
        [DataMember()]
        public string UserId { get; set; }
        [DataMember()]
        public string Action { get; set; }
    }
}
