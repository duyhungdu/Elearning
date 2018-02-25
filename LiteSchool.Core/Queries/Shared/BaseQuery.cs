using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LiteSchool.Core.Queries
{
    /// <summary>
    /// BaseQuery class is used to implement the Query Object Pattern    
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseQuery<T> : IPaginationQuery
    {
        public BaseQuery()
        {
            PageSize = 0;
            SortAscending = true;
        }

        public bool ComputePagesCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SortColumn { get; set; }
        public bool SortAscending { get; set; }

        public bool PagingEnabled
        {
            get
            {
                return PageSize > 0;
            }
            set
            {
                if (value)
                {
                    if (PageSize == 0)
                        throw new Exception("PageSize should be set to a value grather than 0");
                }
                else
                    PageSize = 0;
            }
        }       

        public virtual Expression<Func<T, bool>> ToExpression()
        {            
            return x => true;
        }
    }
}
