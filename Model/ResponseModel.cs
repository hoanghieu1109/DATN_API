using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ResponseModel
    {
        public long TotalSachs { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public dynamic Data { get; set; }
        public int? NullableIndex { get; set; }
        public int? NullableSize { get; set; }
        public long TotalItems { get; set; }
    }
}
