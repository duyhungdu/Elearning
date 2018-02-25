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

    public partial class AspNetUser:BaseEntity<string>
    {
        [DataMember]
        public override string Id { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool EmailConfirmed { get; set; }

        [DataMember]
        public string PasswordHash { get; set; }

        [DataMember]
        public string SecurityStamp { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public bool PhoneNumberConfirmed { get; set; }

        [DataMember]
        public bool TwoFactorEnabled { get; set; }

        [DataMember]
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }

        [DataMember]
        public bool LockoutEnabled { get; set; }

        [DataMember]
        public int AccessFailedCount { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
