using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Dtos
{
    [Serializable]
    [DataContract]
    public partial class CacheEntryDto:BaseDto<string>
    {
        public CacheEntryDto()
        {
        }

        [DataMember]
        public override string Id { get { return Key; } set { Key = value; } }

        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Value { get; set; }
    }
}
