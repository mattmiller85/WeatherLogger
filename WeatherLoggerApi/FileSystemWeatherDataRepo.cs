using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WeatherLoggerApi.Models;

namespace WeatherLoggerApi
{
    public class FileSystemWeatherDataRepo : IWeatherDataRepo
    {
        string _dataPath = HttpContext.Current.Server.MapPath("~/App_Data/weatherdata.json");
        public List<WeatherEntry> GetLatestEntries(int count)
        {
            var entries = JsonConvert.DeserializeObject<List<WeatherEntry>>(File.ReadAllText(_dataPath));
            return entries.OrderByDescending(e => e.TimeStamp).Take(count).ToList();
        }
        public void AddEntry(WeatherEntry entry)
        {
            var entries = JsonConvert.DeserializeObject<List<WeatherEntry>>(File.ReadAllText(_dataPath));
            entries.Add(entry);
            File.WriteAllText(_dataPath, JsonConvert.SerializeObject(entries));
        }
    }
}