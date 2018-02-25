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
    public class LogListTypeConverter : ITypeConverter<ListResponse<Log>, ListResponse<LogDto>>
    {
        public ListResponse<LogDto> Convert(ListResponse<Log> source, ListResponse<LogDto> dest, ResolutionContext context)
        {
            source = new ListResponse<Log>();
            dest = new ListResponse<LogDto>();
            dest.PageNumber = source.PageNumber;
            dest.PageSize = source.PagesCount;
            dest.RowsCount = source.RowsCount;
            dest.Success = source.Success;


            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Log, LogDto>();
            });

            dest.List = Mapper.Map<IList<Log>, IList<LogDto>>(source.List);
            return dest;
        }
    }
}
