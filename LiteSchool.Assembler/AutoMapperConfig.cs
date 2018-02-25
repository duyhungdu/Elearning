using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteSchool.Dtos;
using LiteSchool.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using LiteSchool.Core.Messages;
using LiteSchool.Core.Mappers;
using AutoMapper;
using AutoMapper.Mappers;

namespace LiteSchool.Assembler
{
    public static class AutoMapperConfig
    {
        private static bool s_isInit = false;

        public static void CreateMappings()
        {
            if (s_isInit)
                return;
            s_isInit = true;
            
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CacheProfile>();

                cfg.CreateMap<AspNetRole, AspNetRoleDto>();
                cfg.AddProfile<ListResponseProfile<AspNetRole, AspNetRoleDto>>();
                cfg.CreateMap<AspNetRoleDto, AspNetRole>()
                      .ForMember(x => x.BrokenRules, opt => opt.Ignore());

                cfg.CreateMap<AspNetUser, AspNetUserDto>()
                      .ForMember(x => x.PasswordHash, opt => opt.Ignore());
                cfg.AddProfile<ListResponseProfile<AspNetUser, AspNetUserDto>>();
                cfg.CreateMap<AspNetUserDto, AspNetUser>()
                      .ForMember(x => x.BrokenRules, opt => opt.Ignore())
                      .ForMember(x => x.TwoFactorEnabled, opt => opt.Ignore())
                      .ForMember(x => x.PhoneNumberConfirmed, opt => opt.Ignore())
                      .ForMember(x => x.EmailConfirmed, opt => opt.Ignore());

                cfg.CreateMap<Setting, SettingDto>();
                cfg.AddProfile<ListResponseProfile<Setting, SettingDto>>();
                cfg.CreateMap<SettingDto, Setting>()
                      .ForMember(x => x.BrokenRules, opt => opt.Ignore());

                cfg.CreateMap<Log, LogDto>();
                cfg.CreateMap<ListResponse<Log>, ListResponse<LogDto>>()
                      .ConvertUsing(new LogListTypeConverter());
                cfg.CreateMap<LogDto, Log>()
                      .ForMember(x => x.BrokenRules, opt => opt.Ignore());

               
                cfg.CreateMap<UserLoginInfo, UserLoginInfoTo>();
                cfg.CreateMap<UserLoginInfoTo, UserLoginInfo>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}