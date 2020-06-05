 # Sve-Blazor-DataTable

Blazor DataTable component with support for client/server side paging, filtering and sorting, build on top of bootstrap 4.

![Main gif](/Sve-Blazor-DataTable-Examples/Content/Main.gif)
 
## Getting Started 

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.



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

   Add the following using statement `@using Sve.Blazor.DataTable` to one of the following: 
   - For global import add it to your  `_Imports.razor` file
   - For a scoped import add  it to your desired Blazor component

3. Reference js interop file:
    
    Add `<script src="/_content/Sve.Blazor.DataTable/js/Virtualize.js"></script>` to your _Host.cshtml or your index.html

## Usage

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

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
