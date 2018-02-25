
using LiteSchool.Entities;
using LiteSchool.Core.Messages;
using LiteSchool.Core.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LiteSchool.Dtos;

namespace LiteSchool.Core.IServices
{
    [ServiceContract()]
    public interface IConfigurationService
    {
        #region Setting
        BaseResponse<string> FindSettingValueBy(string name, string defaultValue);
        ListResponse<SettingDto> SearchSettingNonPaging(string keyword);
        ListResponse<SettingDto> SearchSetting(SettingQuery query);
        BaseResponse<SettingDto> AddSetting(SettingDto dto);
        #endregion Setting
    }
}
