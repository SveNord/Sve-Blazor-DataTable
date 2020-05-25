using Sve.Blazor.Core.Models;

namespace Sve.Blazor.DataTable.Components
{
    public class RequestArgs
    {
        public int PageNr { get; set; }

        public int PageSize { get; set; }

        public SortDirection SortDirection { get; set; }

        public string SortColumn { get; set; }

        // TODO: Add filters

        public RequestArgs(int pageNr, int pageSize, SortDirection sortDirection, string sortColumn)
        {
            PageNr = pageNr;
            PageSize = pageSize;
            SortDirection = sortDirection;
            SortColumn = sortColumn;
        }
    }
}
