
using LiteSchool.Entities;
using LiteSchool.Core.IRepository;
using LiteSchool.Core.IServices;
using LiteSchool.Core.Messages;
using LiteSchool.Core.Queries;
using LiteSchool.Library.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LiteSchool.Dtos;
using LiteSchool.Library.Logging;
using AutoMapper;

namespace LiteSchool.Services
{
    public class ConfigurationService : BaseService, IConfigurationService

    {
        private ISettingRepository _settingRepository;
        public ConfigurationService(ILogger logger, ISettingRepository settingRepository)
            : base(logger)
        {
            this._settingRepository = settingRepository;
        }
        #region Setting
        public BaseResponse<string> FindSettingValueBy(string name, string defaultValue)
        {
            BaseResponse<string> response = new BaseResponse<string>();
            response.Value = _settingRepository.FindValueBy(name, defaultValue);
            return response;
        }
        public ListResponse<SettingDto> SearchSettingNonPaging(string name)
        {
            ListResponse<SettingDto> listResponse = new ListResponse<SettingDto>();
            listResponse.List = _settingRepository.SearchSettingNonPaging(name);
            return listResponse;
        }
        public ListResponse<SettingDto> SearchSetting(SettingQuery query)
        {
            ListResponse<SettingDto> listResponse = new ListResponse<SettingDto>();
            listResponse.List = _settingRepository.SearchSetting(query, out listResponse.RowsCount);
            return listResponse;
        }
        public BaseResponse<SettingDto> AddSetting(SettingDto dto)
        {
            var response = new BaseResponse<SettingDto>();
            var entity = Mapper.Map<SettingDto, Setting>(dto);
            if (entity.Validate())
                response.Value = Mapper.Map<Setting, SettingDto>(_settingRepository.Add(entity));
            else
                response.BrokenRules = entity.BrokenRules;
            return response;
        }
        #endregion Setting
    }
}