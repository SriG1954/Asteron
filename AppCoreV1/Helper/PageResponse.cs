using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Helper
{
    public class PageResponse<T> where T : class
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public List<T> Items { get; set; } = null!;

    }
}
