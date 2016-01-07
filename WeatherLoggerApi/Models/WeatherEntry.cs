using System;

namespace WeatherLoggerApi.Models
{
    public class WeatherEntry
    {
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string SoilMoisture { get; set; }
        public string SoilTemperature { get; set; }
        public string RainGauge { get; set; }
        public string Pressure { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}