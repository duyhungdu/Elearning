using AutoMapper;
using AutoMapper.Mappers;
using LiteSchool.Dtos;
using LiteSchool.Entities;
using LiteSchool.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.Mappers
{
    public class ListTypeConverter<TSource, TDest> : ITypeConverter<ListResponse<TSource>, ListResponse<TDest>>
    {
        public ListResponse<TDest> Convert(ListResponse<TSource> source, ListResponse<TDest> dest, ResolutionContext context)
        {
            source = new ListResponse<TSource>();
            dest = new ListResponse<TDest>();
            dest.PageNumber = source.PageNumber;
            dest.PageSize = source.PagesCount;
            dest.RowsCount = source.RowsCount;
            dest.Success = source.Success;
            dest.List = AutoMapper.Mapper.Map<IList<TSource>, IList<TDest>>(source.List);
            return dest;
        }
    }
}
