using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LiteSchool.Core.Messages
{
    [DataContract()]
    public class ListResponse<T> : BaseResponse
    {
        public ListResponse()
        {
            ShowNotification = false;
        }

        [DataMember()]
        public IList<T> List { get; set; }

        [DataMember()]
        public int PageNumber;

        [DataMember()]
        public int PageSize;

        [DataMember()]
        public int PagesCount
        {
            get
            {
                if (PageSize == 0) return 0;
                return (int)Math.Ceiling((decimal)RowsCount/ PageSize);
            }
            internal set { }
        }

        [DataMember()]
        public int RowsCount;
    }
}
