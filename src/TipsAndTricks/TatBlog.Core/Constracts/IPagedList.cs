using System;
using System.Collections.Generic;
using System.Text;
using TatBlog.Core.Collections;

namespace TatBlog.Core.Constracts
{
    public interface IPagedList
    {
        int PagedCount { get; }
        int TotalItemCount { get; }
        int PageIndex { get; }
        int PageNumber { get; }
        int PageSize { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFisrtPage { get; }
        bool IsLastPage { get; }
        int FirstItemIndex { get; }
        int LastItemIndex { get; }
    }

    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        T this[int index] { get; }
        int Count { get; }
    }

}
