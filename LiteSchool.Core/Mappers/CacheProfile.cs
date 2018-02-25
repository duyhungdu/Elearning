using AutoMapper;
using LiteSchool.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.Mappers
{
    public class CacheProfile : Profile
    {
        public CacheProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<KeyValuePair<string, object>, CacheEntryDto>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Key))
                    .ForMember(dest => dest.Value, opts => opts.MapFrom(src => FormatValue(src.Value)));
                cfg.AddProfile<ListResponseProfile<KeyValuePair<string, object>, CacheEntryDto>>();

            });
        }
        public override string ProfileName
        {
            get
            {
                return "CacheProfile";
            }
        }
        private string FormatValue(object value)
        {
            IList list = value as IList;
            if (list != null)
                return string.Format("List : {0}", list.Count);
            else
                return value.ToString();
        }
    }
}
