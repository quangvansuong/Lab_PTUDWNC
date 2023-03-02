using System;
using System.Collections.Generic;
using System.Text;

namespace TatBlog.Core.Constracts
{
    public interface IPagingParams
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        string SortColumn { get; set; }
        string SortOrder { get; set; }



    }
}
