using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteSchool.Core.IRepository;
using LiteSchool.Entities;
using System.Data.Entity;
using LiteSchool.Repositories;
using Dapper;
using LiteSchool.Dtos;
using LiteSchool.Core.Queries;

namespace LiteSchool.Repositories
{
    public class SettingRepository : Repository<int, Setting, SettingDto>, ISettingRepository
    {
        public SettingRepository()
        {

        }
        public string FindValueBy(string name, string defaultValue)
        {
            var result = Query<SettingDto>("SPGetSettingByName",
            new
            {
                @name = name,
                @defaultValue = defaultValue
            });
            return result.FirstOrDefault().Value;
        }
        public List<SettingDto> SearchSettingNonPaging(string keyword)
        {
            return Query<SettingDto>("SPGetSettings_NonPaging", new { @name = keyword }).ToList();
        }
        public List<SettingDto> SearchSetting(SettingQuery query, out int count)
        {
            var start = 0;
            var limit = query.PageSize;
            count = 0;
            start = (query.PageNumber - 1) * limit;
            var data= Query<SettingDto>("SPGetSettings",
                new
                {
                    @keyword = query.Name,
                    @start = start,
                    @limit = limit,
                    @total = count
                }).ToList();
            return data;
        }
    }
}
