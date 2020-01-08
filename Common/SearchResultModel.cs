using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SearchResultModel<T> : ResultModel<T>
    {
        public int TotalRecord { get; set; } = 0;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
