using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LiteSchool.Library.Helpers
{
    public static class EnumHelper<T>
    {
        public static IList<string> ToListOfString(IEnumerable<T> list)
        {
            return list.Select(e => e.ToString()).ToList();
        }

        public static T ToEnum(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
