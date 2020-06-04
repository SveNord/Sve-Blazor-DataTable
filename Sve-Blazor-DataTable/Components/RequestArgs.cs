using Sve.Blazor.Core.Models;
using System.Collections.Generic;

namespace Sve.Blazor.DataTable.Components
{
    public class RequestArgs<TModel>
    {
        public int PageNr { get; set; }

        public int PageSize { get; set; }

        public SortDirection SortDirection { get; set; }

        public string SortColumn { get; set; }

        public IList<FilterRule<TModel>> AppliedFilters { get; set; }

        public RequestArgs(int pageNr, int pageSize, SortDirection sortDirection, string sortColumn, IList<FilterRule<TModel>> appliedFilters)
        {
            PageNr = pageNr;
            PageSize = pageSize;
            SortDirection = sortDirection;
            SortColumn = sortColumn;
            AppliedFilters = appliedFilters;
        }
    }
}
