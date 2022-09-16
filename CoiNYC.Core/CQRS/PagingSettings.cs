using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.CQRS
{
    public class PagingSettings
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public bool IsSortAscending { get; set; }
        public string SortColumn { get; set; }  
    }
}
