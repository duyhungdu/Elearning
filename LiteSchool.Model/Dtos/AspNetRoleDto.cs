//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiteSchool.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public partial class AspNetRoleDto:BaseDto<string>
    {
        public AspNetRoleDto()
        {

        }
        [DataMember]
        public override string Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
