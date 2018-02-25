using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LiteSchool.Entities;
using LiteSchool.Library.Extensions.Expressions;

namespace LiteSchool.Core.Queries
{
    public class LogQuery : BaseQuery<Log>
    {
        public string Keyword { get; set; }

        public override Expression<Func<Log, bool>> ToExpression()
        {
            Expression<Func<Log, bool>> predicate = x => true;
            if (!string.IsNullOrEmpty(Keyword))
            {
                predicate = predicate.And(x => x.Message.Contains(Keyword));
            }
            return predicate;
        }
    }
}
