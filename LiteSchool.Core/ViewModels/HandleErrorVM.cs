using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    [DataContract]
    public class HandleErrorVM
    {
        [DataMember]
        public Guid Ticket { get; set; }

        [DataMember]
        public string ActionName { get; set; }

        [DataMember]
        public string ControllerName { get; set; }
    }
}
