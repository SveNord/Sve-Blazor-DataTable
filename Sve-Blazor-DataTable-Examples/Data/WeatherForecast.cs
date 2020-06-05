using System;

namespace Sve.Blazor.DataTable.Examples.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int? MyNullableInt { get; set; }

        public string Summary { get; set; }
    
        public Country Country { get; set; }
        
        public bool UpdatedRecently { get; set; }
    }
}
