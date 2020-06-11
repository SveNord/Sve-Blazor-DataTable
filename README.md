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
    
    Add `<script src="/_content/Sve.Blazor.DataTable/js/DataTable.js"></script>` to your _Host.cshtml or your index.html

## Usage

### DataTable properties
<table style="width: 1005px;">
<tbody>
<tr>
<td style="width: 271px;"><strong>Name</strong></td>
<td style="width: 198px;"><strong>Type</strong></td>
<td style="width: 14px;"><strong>Default</strong></td>
<td style="width: 521px;"><strong>Description</strong></td>
</tr>
<tr>
<td style="width: 271px;">Items</td>
<td style="width: 198px;">IList</td>
<td style="width: 14px;">List</td>
<td style="width: 521px;">The list of items to display</td>
</tr>
<tr>
<td style="width: 271px;">UsePaging</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Boolean indicating whether to use paging or not</td>
</tr>
<tr>
<td style="width: 271px;">PageNr</td>
<td style="width: 198px;">int</td>
<td style="width: 14px;">1</td>
<td style="width: 521px;">The number of the current page (only applicable when property UsePaging is true)</td>
</tr>
<tr>
<td style="width: 271px;">PageSize</td>
<td style="width: 198px;">int</td>
<td style="width: 14px;">10</td>
<td style="width: 521px;">The amount of items shown on a page (only applicable when property UsePaging is true)</td>
</tr>
<tr>
<td style="width: 271px;">PageCount</td>
<td style="width: 198px;">int</td>
<td style="width: 14px;">1</td>
<td style="width: 521px;">The total amount of pages (only applicable when property UsePaging is true)</td>
</tr>
<tr>
<td style="width: 271px;">FetchData</td>
<td style="width: 198px;">Func&lt;RequestArgs, Task&gt;?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The method used for fetching and manipulating data (paging, filtering, sorting) on the server. When this method is null, all these actions will be performed on the initial dataset on the client.</td>
</tr>
<tr>
<td style="width: 271px;">ShowHeaderFilters</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">true</td>
<td style="width: 521px;">Indicates whether or not to show the header/grid filters</td>
</tr>
<tr>
<td style="width: 271px;">AllowRowSelection</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not it's possible to select a row</td>
</tr>
<tr>
<td style="width: 271px;">RowClickedEvent</td>
<td style="width: 198px;">EventCallback</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The callback for when a row is clicked (only applicable when property AllowRowSelection is true)</td>
</tr>
<tr>
<td style="width: 271px;">SelectedItem</td>
<td style="width: 198px;">TModel</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The selected item</td>
</tr>
<tr>
<td style="width: 271px;">SelectedItemCssClass</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">bg-info</td>
<td style="width: 521px;">The css class for the selected row</td>
</tr>
<tr>
<td style="width: 271px;">EmptyGridText</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">"No records to show"</td>
<td style="width: 521px;">The text to show when the Items list is empty</td>
</tr>
<tr>
<td style="width: 271px;">IsLoading</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not data is being fetched, used to show a spinner</td>
</tr>
<tr>
<td style="width: 271px;">Id</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">""</td>
<td style="width: 521px;">The html identifier of the table tag</td>
</tr>
<tr>
<td style="width: 271px;">ContainerCssClass</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">"table-responsive"</td>
<td style="width: 521px;">The css class for the container/parent tag of the table</td>
</tr>
<tr>
<td style="width: 271px;">CssClass</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">"table"</td>
<td style="width: 521px;">The css class for the table tag</td>
</tr>
<tr>
<td style="width: 271px;">ApplyButtonCssClass</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">""</td>
<td style="width: 521px;">The css class for the "apply" buttons on grid/header filters</td>
</tr>
<tr>
<td style="width: 271px;">InputCssClass</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">""</td>
<td style="width: 521px;">The css class for the input tags in the grid/header filters</td>
</tr>
<tr>
<td style="width: 271px;">Styles</td>
<td style="width: 198px;">TableStyle [Enum FLAGS]</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The style flags used for the table</td>
</tr>
<tr>
<td style="width: 271px;">TableAttributes</td>
<td style="width: 198px;">Dictionary&lt;string, object&gt;?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">Any custom attributes for the table tag (see Blazor docs for more info)</td>
</tr>
<tr>
<td style="width: 271px;">RowAttributes</td>
<td style="width: 198px;">Dictionary&lt;string, object&gt;?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">Any custom attributes for the rows (see Blazor docs for more info)</td>
</tr>
<tr>
<td style="width: 271px;">ContainerHeight</td>
<td style="width: 198px;">int</td>
<td style="width: 14px;">300</td>
<td style="width: 521px;">The height of the table container in pixels</td>
</tr>
<tr>
<td style="width: 271px;">IncludeAdvancedFilters</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">true</td>
<td style="width: 521px;">Indicates whether to allow advanced filtering or not</td>
</tr>
<tr>
<td style="width: 271px;">IncludeHeaderFilters</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to include grid/header filters</td>
</tr>
<tr>
<td style="width: 271px;">IncludeSearchButton</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client</td>
</tr>
<tr>
<td style="width: 271px;">IncludeToggleFilters</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property</td>
</tr>
<tr>
<td style="width: 271px;">SearchOnApplyHeaderFilter</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">true</td>
<td style="width: 521px;">Indicates whether or not a search is instantly triggered when a header/grid filter is applied</td>
</tr>
<tr>
<td style="width: 271px;">AutoAddFilterWhenClickedAndNoneActive</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">true</td>
<td style="width: 521px;">Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist.</td>
</tr>
</tbody>
</table>

### DataTableColumn properties

<table style="width: 1005px;">
<thead>
<tr>
<th style="width: 271px;">Name</th>
<th style="width: 198px;">Type</th>
<th style="width: 14px;">Default</th>
<th style="width: 521px;">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td style="width: 271px;">Property</td>
<td style="width: 198px;">Expression&lt;Func&lt;TModel, object&gt;&gt;?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The selector of a field/property of TModel to use for the column</td>
</tr>
<tr>
<td style="width: 271px;">IsSortable</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not sorting is enabled for this column</td>
</tr>
<tr>
<td style="width: 271px;">IsFilterable</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not filtering is enabled for this column</td>
</tr>
<tr>
<td style="width: 271px;">CustomTitle</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The name of the column header (by default the name of the property is used)</td>
</tr>
<tr>
<td style="width: 271px;">HeaderTemplate</td>
<td style="width: 198px;">RenderFragment&lt;string&gt;</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The template to use for the grid header, the string is the name of the column</td>
</tr>
<tr>
<td style="width: 271px;">Id</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">""</td>
<td style="width: 521px;">The html identifier of the table tag</td>
</tr>
<tr>
<td style="width: 271px;">ContainerCssClass</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">"table-responsive"</td>
<td style="width: 521px;">The css class for the container/parent tag of the table</td>
</tr>
<tr>
<td style="width: 271px;">CssClass</td>
<td style="width: 198px;">string</td>
<td style="width: 14px;">"table"</td>
<td style="width: 521px;">The css class for the table tag</td>
</tr>
<tr>
<td style="width: 271px;">IsDefaultSortColumn</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not this column is sorted on by default</td>
</tr>
<tr>
<td style="width: 271px;">DefaultSortDirection</td>
<td style="width: 198px;">SortDirection [Enum]</td>
<td style="width: 14px;">SortDirection.Ascending</td>
<td style="width: 521px;">The sort direction of the default sorting column</td>
</tr>
<tr>
<td style="width: 271px;">TextAlignment</td>
<td style="width: 198px;">TextAlignment [Enum]</td>
<td style="width: 14px;">TextAlignment.Left</td>
<td style="width: 521px;">The text alignment for the column</td>
</tr>
<tr>
<td style="width: 271px;">VerticalAlignment</td>
<td style="width: 198px;">VerticalAlignment [Enum]</td>
<td style="width: 14px;">VerticalAlignment.Bottom</td>
<td style="width: 521px;">The vertical alignment for the column</td>
</tr>
<tr>
<td style="width: 271px;">Styles</td>
<td style="width: 198px;">TableStyle [Enum FLAGS]</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The style flags used for the table</td>
</tr>
<tr>
<td style="width: 271px;">Attributes</td>
<td style="width: 198px;">Dictionary&lt;string, object&gt;?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">Any custom attributes for the table tag (see Blazor docs for more info)</td>
</tr>
<tr>
<td style="width: 271px;">HeaderFilterAttributes</td>
<td style="width: 198px;">Dictionary&lt;string, object&gt;?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">Any custom attributes for the header inputs</td>
</tr>
<tr>
<td style="width: 271px;">ContainerHeight</td>
<td style="width: 198px;">int</td>
<td style="width: 14px;">300</td>
<td style="width: 521px;">The height of the table container in pixels</td>
</tr>
<tr>
<td style="width: 271px;">IncludeHeaderFilter</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to add header/grid filters</td>
</tr>
<tr>
<td style="width: 271px;">IncludeSearchButton</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client</td>
</tr>
<tr>
<td style="width: 271px;">IncludeToggleFilters</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property</td>
</tr>
<tr>
<td style="width: 271px;">SearchOnApplyHeaderFilter</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not a search is instantly triggered when a header/grid filter is applied</td>
</tr>
<tr>
<td style="width: 271px;">AutoAddFilterWhenClickedAndNoneActive</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">true</td>
<td style="width: 521px;">Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist.</td>
</tr>
<tr>
<td style="width: 271px;">RowTemplate</td>
<td style="width: 198px;">RenderFragment?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">The custom render fragment to use for the column</td>
</tr>
<tr>
<td style="width: 271px;">RowAttributes</td>
<td style="width: 198px;">Dictionary&lt;string, object&gt;?</td>
<td style="width: 14px;">null</td>
<td style="width: 521px;">Any custom attributes for the rows (see Blazor docs for more info)</td>
</tr>
<tr>
<td style="width: 271px;">ContainerHeight</td>
<td style="width: 198px;">int</td>
<td style="width: 14px;">300</td>
<td style="width: 521px;">The height of the table container in pixels</td>
</tr>
<tr>
<td style="width: 271px;">MaxWidth</td>
<td style="width: 198px;">int</td>
<td style="width: 14px;">100</td>
<td style="width: 521px;">The max width in pixels of a column</td>
</tr>
<tr>
<td style="width: 271px;">DateTimeFormat</td>
<td style="width: 198px;">DateTimeFormat</td>
<td style="width: 14px;">DateTimeFormat.Date</td>
<td style="width: 521px;">The DateTimeFormat to use in header/grid filters</td>
</tr>
<tr>
<td style="width: 271px;">IsHeaderVisible</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">true</td>
<td style="width: 521px;">Indicates whether the column is visible or not</td>
</tr>
<tr>
<td style="width: 271px;">IncludeAdvancedFilters</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether to allow advanced filtering or not</td>
</tr>
<tr>
<td style="width: 271px;">IncludeSearchButton</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client</td>
</tr>
<tr>
<td style="width: 271px;">IncludeToggleFilters</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property</td>
</tr>
<tr>
<td style="width: 271px;">SearchOnApplyHeaderFilter</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">false</td>
<td style="width: 521px;">Indicates whether or not a search is instantly triggered when a header/grid filter is applied</td>
</tr>
<tr>
<td style="width: 271px;">AutoAddFilterWhenClickedAndNoneActive</td>
<td style="width: 198px;">bool</td>
<td style="width: 14px;">true</td>
<td style="width: 521px;">Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist.</td>
</tr>
</tbody>
</table>

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
