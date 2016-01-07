using System.Collections.Generic;
using WeatherLoggerApi.Models;

namespace WeatherLoggerApi
{
    public interface IWeatherDataRepo
    {
        List<WeatherEntry> GetLatestEntries(int count);
        void AddEntry(WeatherEntry entry);
    }
}
