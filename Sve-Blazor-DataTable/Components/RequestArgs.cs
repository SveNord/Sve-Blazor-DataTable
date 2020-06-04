using Sve.Blazor.Core.Models;
using System.Collections.Generic;

namespace Sve.Blazor.DataTable.Components
{
    public class RequestArgs<TModel>
    {
        //public int PageNr { get; set; }

        //public int PageSize { get; set; }

        //public SortDirection SortDirection { get; set; }

        //public string SortColumn { get; set; }

        public Pager Pager { get; private set; }

        public IList<FilterRule<TModel>> AppliedFilters { get; private set; }

        public RequestArgs(int pageNr, int pageSize, SortDirection sortDirection, string sortColumn, IList<FilterRule<TModel>> appliedFilters)
        {
            Pager = new Pager(pageNr, pageSize, sortColumn, sortDirection);
            AppliedFilters = appliedFilters;
        }

        public RequestArgs(Pager pager, IList<FilterRule<TModel>> appliedFilters)
        {
            Pager = pager;
            AppliedFilters = appliedFilters;
        }
    }
}
