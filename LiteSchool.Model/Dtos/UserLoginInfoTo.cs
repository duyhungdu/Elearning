using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Dtos
{
    [DataContract]
    public class UserLoginInfoTo
    {             
        // Summary:
        //     Provider for the linked login, i.e. Facebook, Google, etc.
        [DataMember]
        public string LoginProvider { get; set; }
        //
        // Summary:
        //     User specific key for the login provider
        [DataMember]
        public string ProviderKey { get; set; }
    }
}
