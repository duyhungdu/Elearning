using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LiteSchool.Entities;
using LiteSchool.Library.Extensions.Expressions;

namespace LiteSchool.Core.Queries
{
    public class UserQuery : BaseQuery<AspNetUser>
    {
        public string UserName { get; set; }

        public override Expression<Func<AspNetUser, bool>> ToExpression()
        {
            Expression<Func<AspNetUser, bool>> predicate = x => true;
            if (!string.IsNullOrWhiteSpace(UserName))
                predicate = predicate.And(x => x.UserName.StartsWith(UserName));

            return predicate;
        }
    }
}
