using AutoMapper;
using LiteSchool.Core.Messages;
using LiteSchool.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.Mappers
{
    public static class MapperExtensions
    {
        public static ListResponse<TDestination> Map<TSource, TDestination>(this ListResponse<TSource> sourceResponse)
        {
            return Mapper.Map<ListResponse<TSource>, ListResponse<TDestination>>(sourceResponse);
        }

        public static TDestination Map<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public static IList<TDestination> Map<TSource, TDestination>(this IList<TSource> list)
        {
            return Mapper.Map<IList<TSource>, IList<TDestination>>(list);
        }
    }
}
