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
    public abstract class BaseDto<TId>
    {
        [DataMember]
        public abstract TId Id { get; set; }
    }
}
