using AutoMapper;
using LiteSchool.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.Mappers
{
    public class ListResponseProfile<TSource, TDestination> : Profile
    {
        public ListResponseProfile()
        {
            CreateMap<ListResponse<TSource>, ListResponse<TDestination>>()
              .ConvertUsing(new ListTypeConverter<TSource, TDestination>());
        }
        public override string ProfileName
        {
            get
            {
                return "ListResponseProfile";
            }
        }
    }
}
