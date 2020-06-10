 # Sve-Blazor-DataTable

Blazor DataTable component with support for client/server side paging, filtering and sorting, build on top of bootstrap 4.

![Main gif](/Sve-Blazor-DataTable-Examples/Content/Main.gif)
 

## Important Notice
This project is still under active development! Currently an alpha version is available on NuGet, but keep in mind that a later version might contain breaking changes. Make sure to always check the [Changelog](CHANGELOG.md) for more information.


### Installation
1. Install the [NuGet](https://www.nuget.org/packages/Sve.Blazor.DataTable/) package:

   ```
   > dotnet add package Sve.Blazor.DataTable
   
   OR
   
   PM> Install-Package Sve.Blazor.DataTable
   ```
   Use the `--version` option to specify a specific version to install.

   Or use the build in NuGet package manager of your favorite IDEA. Simply search for `Sve.Blazor.DataTable`, select a version and hit install.

2. Import the components:

   Add the following using statement `@using Sve.Blazor.DataTable.Components` to one of the following: 
   - For global import add it to your  `_Imports.razor` file
   - For a scoped import add  it to your desired Blazor component

3. Reference js interop file:
    
    Add `<script src="/_content/Sve.Blazor.DataTable/js/Virtualize.js"></script>` to your _Host.cshtml or your index.html

## Usage

### DataTable properties
| Name                                  | Type                        | Default              | Description                                                                                                                                                                                        |
|---------------------------------------|-----------------------------|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Items                                 | IList                       | List                 | The list of items to display                                                                                                                                                                       |
| UsePaging                             | bool                        | false                | Boolean indicating whether to use paging or not                                                                                                                                                    |
| PageNr                                | int                         | 1                    | The number of the current page (only applicable when property UsePaging is true)                                                                                                                   |
| PageSize                              | int                         | 10                   | The amount of items shown on a page (only applicable when property UsePaging is true)                                                                                                              |
| PageCount                             | int                         | 1                    | The total amount of pages (only applicable when property UsePaging is true)                                                                                                                        |
| FetchData                             | Func<RequestArgs, Task>?    | null                 | The method used for fetching and manipulating data (paging, filtering, sorting) on the server. When this method is null, all these actions will be performed on the initial dataset on the client. |
| ShowHeaderFilters                     | bool                        | true                 | Indicates whether or not to show the header/grid filters                                                                                                                                           |
| AllowRowSelection                     | bool                        | false                | Indicates whether or not it's possible to select a row                                                                                                                                             |
| RowClickedEvent                       | EventCallback               | null                 | The callback for when a row is clicked (only applicable when property AllowRowSelection is true)                                                                                                   |
| SelectedItem                          | TModel                      | null                 | The selected item                                                                                                                                                                                  |
| SelectedItemCssClass                  | string                      | bg-info              | The css class for the selected row                                                                                                                                                                 |
| EmptyGridText                         | string                      | "No records to show" | The text to show when the Items list is empty                                                                                                                                                      |
| IsLoading                             | bool                        | false                | Indicates whether or not data is being fetched, used to show a spinner                                                                                                                             |
| Id                                    | string                      | ""                   | The html identifier of the table tag                                                                                                                                                               |
| ContainerCssClass                     | string                      | "table-responsive"   | The css class for the container/parent tag of the table                                                                                                                                            |
| CssClass                              | string                      | "table"              | The css class for the table tag                                                                                                                                                                    |
| ApplyButtonCssClass                   | string                      | ""                   | The css class for the "apply" buttons on grid/header filters                                                                                                                                       |
| InputCssClass                         | string                      | ""                   | The css class for the input tags in the grid/header filters                                                                                                                                        |
| Styles                                | TableStyle [Enum FLAGS]     | null                 | The style flags used for the table                                                                                                                                                                 |
| TableAttributes                       | Dictionary<string, object>? | null                 | Any custom attributes for the table tag (see Blazor docs for more info)                                                                                                                            |
| RowAttributes                         | Dictionary<string, object>? | null                 | Any custom attributes for the rows (see Blazor docs for more info)                                                                                                                                 |
| ContainerHeight                       | int                         | 300                  | The height of the table container in pixels                                                                                                                                                        |
| IncludeAdvancedFilters                | bool                        | false                | Indicates whether to allow advanced filtering or not                                                                                                                                               |
| IncludeHeaderFilters                  | bool                        | false                | Indicates whether or not to include grid/header filters                                                                                                                                            |
| IncludeSearchButton                   | bool                        | false                | Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client                 |
| IncludeToggleFilters                  | bool                        | false                | Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property                                                            |
| SearchOnApplyHeaderFilter             | bool                        | false                | Indicates whether or not a search is instantly triggered when a header/grid filter is applied                                                                                                      |
| AutoAddFilterWhenClickedAndNoneActive | bool                        | true                 | Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist.                                                                           |
### DataTableColumn properties
| Name                                  | Type                              | Default                  | Description                                                                                                                                                                        |   |
|---------------------------------------|-----------------------------------|--------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---|
| Property                              | Expression<Func<TModel, object>>? | null                     | The selector of a field/property of TModel to use for the column                                                                                                                   |   |
| IsSortable                            | bool                              | false                    | Indicates whether or not sorting is enabled for this column                                                                                                                        |   |
| IsFilterable                          | bool                              | false                    | Indicates whether or not filtering is enabled for this column                                                                                                                      |   |
| CustomTitle                           | string                            | null                     | The name of the column header (by default the name of the property is used)                                                                                                        |   |
| HeaderTemplate                        | RenderFragment<string>            | null                     | The template to use for the grid header, the string is the name of the column                                                                                                      |   |
| Id                                    | string                            | ""                       | The html identifier of the table tag                                                                                                                                               |   |
| ContainerCssClass                     | string                            | "table-responsive"       | The css class for the container/parent tag of the table                                                                                                                            |   |
| CssClass                              | string                            | "table"                  | The css class for the table tag                                                                                                                                                    |   |
| IsDefaultSortColumn                   | bool                              | false                    | Indicates whether or not this column is sorted on by default                                                                                                                       |   |
| DefaultSortDirection                  | SortDirection [Enum]              | SortDirection.Ascending  | The sort direction of the default sorting column                                                                                                                                   |   |
| TextAlignment                         | TextAlignment [Enum]              | TextAlignment.Left       | The text alignment for the column                                                                                                                                                  |   |
| VerticalAlignment                     | VerticalAlignment [Enum]          | VerticalAlignment.Bottom | The vertical alignment for the column                                                                                                                                              |   |
| Styles                                | TableStyle [Enum FLAGS]           | null                     | The style flags used for the table                                                                                                                                                 |   |
| Attributes                            | Dictionary<string, object>?       | null                     | Any custom attributes for the table tag (see Blazor docs for more info)                                                                                                            |   |
| HeaderFilterAttributes                | Dictionary<string, object>?       | null                     | Any custom attributes for the header inputs                                                                                                                                        |   |
| ContainerHeight                       | int                               | 300                      | The height of the table container in pixels                                                                                                                                        |   |
| IncludeHeaderFilter                   | bool                              | false                    | Indicates whether or not to add header/grid filters                                                                                                                                |   |
| IncludeSearchButton                   | bool                              | false                    | Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client |   |
| IncludeToggleFilters                  | bool                              | false                    | Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property                                            |   |
| SearchOnApplyHeaderFilter             | bool                              | false                    | Indicates whether or not a search is instantly triggered when a header/grid filter is applied                                                                                      |   |
| AutoAddFilterWhenClickedAndNoneActive | bool                              | true                     | Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist.                                                           |   |
| RowTemplate                           | RenderFragment?                   | null                     | The custom render fragment to use for the column                                                                                                                                   |   |
| RowAttributes                         | Dictionary<string, object>?       | null                     | Any custom attributes for the rows (see Blazor docs for more info)                                                                                                                 |   |
| ContainerHeight                       | int                               | 300                      | The height of the table container in pixels                                                                                                                                        |   |
| MaxWidth                              | int                               | 100                      | The max width in pixels of a column                                                                                                                                                |   |
| DateTimeFormat                        | DateTimeFormat                    | DateTimeFormat.Date      | The DateTimeFormat to use in header/grid filters                                                                                                                                   |   |
| IsHeaderVisible                       | bool                              | true                     | Indicates whether the column is visible or not                                                                                                                                     |   |
| IncludeAdvancedFilters                | bool                              | false                    | Indicates whether to allow advanced filtering or not                                                                                                                               |   |
| IncludeSearchButton                   | bool                              | false                    | Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client |   |
| IncludeToggleFilters                  | bool                              | false                    | Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property                                            |   |
| SearchOnApplyHeaderFilter             | bool                              | false                    | Indicates whether or not a search is instantly triggered when a header/grid filter is applied                                                                                      |   |
| AutoAddFilterWhenClickedAndNoneActive | bool                              | true                     | Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist.                                                           |   |

### Basic table

```cs
<DataTable TModel="WeatherForecast" Items="forecasts">
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.TemperatureC" CustomTitle="Celsius"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Summary"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Country"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated"/>
</DataTable>
```
![Basic example](/Sve-Blazor-DataTable-Examples/Content/BasicExample.PNG)

<br />
<br />

### Custom template

```cs
<DataTable TModel="WeatherForecast" Items="forecasts">
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.TemperatureC" CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated">
        <Template Context="forecast">
            @if (forecast.UpdatedRecently)
            {
                <i class="fas fa-check-circle" style="color: green;"></i>
            }
            else
            {
                <i class="far fa-times-circle" style="color: red;"></i>
            }
        </Template>
    </DataTableColumn>
</DataTable>
```

![Template example](Sve-Blazor-DataTable-Examples/Content/CustomTemplateExample.PNG)

<br />
<br />

### Sorting

```cs
<DataTable TModel="WeatherForecast" Items="forecasts">
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" Property="(e) => e.Date"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" Property="(e) => e.TemperatureC" CustomTitle="Celsius"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Summary"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" Property="(e) => e.Country"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated"/>
</DataTable>
```

![Sorting example](/Sve-Blazor-DataTable-Examples/Content/SortingExample.gif)

<br />
<br />

### Pagination

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" UsePaging="true">
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Date"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.TemperatureC" CustomTitle="Celsius"   />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Summary"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.Country"/>
    <DataTableColumn TModel="WeatherForecast" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated"/>
</DataTable>
```

![Paging example](/Sve-Blazor-DataTable-Examples/Content/PagingExample.gif)

<br />
<br />

### Filtering

```cs
<DataTable TModel="WeatherForecast" Items="forecasts">
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" Property="(e) => e.Date"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" Property="(e) => e.TemperatureC" CustomTitle="Celsius"   />
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" Property="(e) => e.Summary"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" Property="(e) => e.Country"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated"/>
    </DataTable>
```

![Filtering example](/Sve-Blazor-DataTable-Examples/Content/FilteringExample.gif)

<br />
<br />

### Header/Grid filters

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" SearchOnApplyHeaderFilter="true">
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" IncludeHeaderFilter="true" Property="(e) => e.Date"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" IncludeHeaderFilter="true" Property="(e) => e.TemperatureC" CustomTitle="Celsius"   />
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" IncludeHeaderFilter="true" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" IncludeHeaderFilter="true" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" IncludeHeaderFilter="true" Property="(e) => e.Summary"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" IncludeHeaderFilter="true" Property="(e) => e.Country"/>
    <DataTableColumn TModel="WeatherForecast" IsFilterable="true" IncludeHeaderFilter="true" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated"/>
    </DataTable>
```

![Header filtering example](/Sve-Blazor-DataTable-Examples/Content/HeaderFilteringExample.gif)

<br />
<br />

### Out of the box Virtualization

```cs
<DataTable TModel="WeatherForecast" Items="forecasts">
    <DataTableColumn TModel="WeatherForecast">
        <Template Context="forecast">
            @(Array.IndexOf(forecasts, forecast) + 1)
        </Template>
    </DataTableColumn>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.Date"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.TemperatureC" CustomTitle="Celsius"   />
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.Summary"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.Country"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated"/>
    </DataTable>
```

![Virtualization example](/Sve-Blazor-DataTable-Examples/Content/VirtualizationExample.gif)

<br />
<br />

### Server side support

```cs
<DataTable TModel="WeatherForecast" Items="pagedForecasts.Data" UsePaging="true" FetchData="DoFetchData" PageCount="@pagedForecasts.Paging.PageCount" PageSize="@pagedForecasts.Paging.PageSize">
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.Date"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.TemperatureC" CustomTitle="Celsius"   />
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.Summary"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.Country"/>
    <DataTableColumn TModel="WeatherForecast" IsSortable="true" IsFilterable="true" Property="(e) => e.UpdatedRecently" CustomTitle="Recently updated"/>
</DataTable>

// Method will be called by the DataTable when necessary
private async Task DoFetchData(RequestArgs<WeatherForecast> args)
{
    pagedForecasts = await ForecastService.SearchForecastAsync(args);
    // Don't forget to call StateHasChanged() since your component is the owner of the DataTable
    StateHasChanged();
}

// ForecastService:
public async Task SearchForecastAsync(RequestArgs<WeatherForecast> args)
{
    IQueryable<WeatherForecast> result = context.Forecasts.AsQueryable();

    // RequestArgs contains all the information about sorting, paging and filtering
    foreach (var filter in args.AppliedFilters)
    {
        // Filters can easily be translated into expressions, 
        // or use the filtering info to create your own filtering solution
        result = result.Where(filter.GenerateExpression());
    }
    
    // Use the Core.Utils to easily apply paging and sorting
    // Or use the paging info in RequestArgs to build your own paging solution
    pagedResult = Sve.Blazor.Core.Utils.ApplyPaging(result, pager);

    return Task.FromResult(pagedResult);
}
```

![Server side example](/Sve-Blazor-DataTable-Examples/Content/ServerSideExample.gif)

<br />
<br />

### Support bootstrap table styles

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Sm">
....
</DataTable>
```

![Small table example](/Sve-Blazor-DataTable-Examples/Content/SmallTableExample.PNG)
<br />
<br />


```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Bordered">
....
</DataTable>
```

![Bordered table example](/Sve-Blazor-DataTable-Examples/Content/BorderedTableExample.PNG)

<br />
<br />

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Borderless">
....
</DataTable>
```

![Borderless table example](/Sve-Blazor-DataTable-Examples/Content/BorderlessTableExample.PNG)

<br />
<br />

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Dark">
....
</DataTable>
```

![Dark table example](/Sve-Blazor-DataTable-Examples/Content/DarkTableExample.PNG)

<br />
<br />


```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Hover">
....
</DataTable>
```

![Hoverable table example](/Sve-Blazor-DataTable-Examples/Content/HoverableTableExample.PNG)

<br />
<br />


```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Striped">
....
</DataTable>
```

![Striped table example](/Sve-Blazor-DataTable-Examples/Content/StripedTableExample.PNG)

<br />
<br />

### Alignment

```cs
<DataTable TModel="WeatherForecast" Items="forecasts">
    <DataTableColumn TModel="WeatherForecast" TextAlignment="Core.Models.TextAlignment.Center" IsSortable="true" Property="(e) => e.Date"/>
    <DataTableColumn TModel="WeatherForecast" TextAlignment="Core.Models.TextAlignment.End" IsSortable="true" Property="(e) => e.TemperatureC" CustomTitle="Celsius"   />
    <DataTableColumn TModel="WeatherForecast" TextAlignment="Core.Models.TextAlignment.Left" IsSortable="true" Property="(e) => e.TemperatureF" CustomTitle="Fahrenheit"/>
    <DataTableColumn TModel="WeatherForecast" TextAlignment="Core.Models.TextAlignment.Right" IsSortable="true" Property="(e) => e.MyNullableInt"/>
    <DataTableColumn TModel="WeatherForecast" TextAlignment="Core.Models.TextAlignment.Start" IsSortable="true" Property="(e) => e.Summary"/>
</DataTable>
```

![Alignment example](/Sve-Blazor-DataTable-Examples/Content/AlignmentExample.PNG)

<br />
<br />

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
