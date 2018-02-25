using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.Queries
{
    public interface IPaginationQuery
    {
        bool ComputePagesCount { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        bool PagingEnabled { get; set; }
        bool SortAscending { get; set; }
        string SortColumn { get; set; }
    }
}
