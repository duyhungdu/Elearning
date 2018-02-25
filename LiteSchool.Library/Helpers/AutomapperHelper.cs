using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteSchool.Library.Helpers
{
    public class AutoMapperHelper
    {
        /// <summary>
        /// Mapping list
        /// AutoMaper has problems to map list, and this helper was create to solve this issue
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> list)
        {
            List<TDestination> vmList = new List<TDestination>();
            foreach (TSource e in list.ToList<TSource>())
                vmList.Add(AutoMapper.Mapper.Map<TSource, TDestination>(e));

            return vmList;
        }
    }
}
