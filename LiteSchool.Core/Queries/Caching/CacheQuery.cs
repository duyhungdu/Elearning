using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LiteSchool.Library.Extensions.Expressions;

namespace LiteSchool.Core.Queries
{
    public class CacheQuery : BaseQuery<KeyValuePair<string, object>>
    {
        public string Key { get; set; }

        public override Expression<Func<KeyValuePair<string, object>, bool>> ToExpression()
        {
            Expression<Func<KeyValuePair<string, object>, bool>> predicate = x => true;
            if (!string.IsNullOrWhiteSpace(Key))
                predicate = predicate.And(x => x.Key.StartsWith(Key));

            return predicate;
        }
    }
}
