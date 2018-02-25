using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LiteSchool.Library.Extensions.Expressions;
using LiteSchool.Entities;

namespace LiteSchool.Core.Queries
{
    public class RoleQuery : BaseQuery<AspNetRole>
    {
        public string Name { get; set; }

        public override Expression<Func<AspNetRole, bool>> ToExpression()
        {
            Expression<Func<AspNetRole, bool>> predicate = x => true;
            if (!string.IsNullOrWhiteSpace(Name))
                predicate = predicate.And(x => x.Name.StartsWith(Name));

            return predicate;
        }        
    }   
}
