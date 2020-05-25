using System;

namespace Sve.Blazor.DataTable.Components
{
    [Flags]
    public enum TableStyle
    {
        Dark = 1,
        Striped = 2,
        Bordered = 4,
        Borderless = 8,
        Hover = 16,
        Sm = 32,
    }
}
