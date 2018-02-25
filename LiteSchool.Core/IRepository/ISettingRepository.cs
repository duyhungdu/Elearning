using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteSchool.Entities;
using LiteSchool.Dtos;
using LiteSchool.Core.Queries;

namespace LiteSchool.Core.IRepository
{
    public interface ISettingRepository : IRepository<int, Setting, SettingDto>
    {
        string FindValueBy(string name, string defaultValue);
        List<SettingDto> SearchSettingNonPaging(string keyword);
        List<SettingDto> SearchSetting(SettingQuery query, out int count);
    }
}
