using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Common.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; }

        public int TotalCount { get;}

        public int PageSize { get; }

        public int PageNumber { get; }

        public int TotalPages { get; }

        public bool HasNext => PageNumber < TotalPages;

        public bool HasPreviouse => PageNumber > 1;

        public PagedResult(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }

}
