//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiteSchool.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public partial class AspNetUserLogin
    {
        [DataMember]
        public string LoginProvider { get; set; }

        [DataMember]
        public string ProviderKey { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }
}
