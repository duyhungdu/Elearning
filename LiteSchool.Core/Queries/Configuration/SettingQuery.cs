using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LiteSchool.Entities;
using LiteSchool.Library.Extensions.Expressions;


namespace LiteSchool.Core.Queries
{
    public class SettingQuery:BaseQuery<Setting>
    {
        public string Name { get; set; }
        public override Expression<Func<Setting, bool>> ToExpression()
        {
            Expression<Func<Setting, bool>> predicate = x => true;
            if (!string.IsNullOrEmpty(Name))
            {
                predicate = predicate.And(x => x.Name.Contains(Name));
            }
            return predicate;
        }
    }
}
