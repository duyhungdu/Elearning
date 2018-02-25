using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteSchool.Library.Domain;

namespace LiteSchool.Entities
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; set; }

        List<ValidationRule> BrokenRules { get; set; }        
        bool Validate();
    }
}
