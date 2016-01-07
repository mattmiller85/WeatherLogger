using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherLoggerApi.Models;

namespace WeatherLoggerApi.Controllers
{
    public class WeatherController : ApiController
    {
        IWeatherDataRepo _repo;
        public WeatherController(IWeatherDataRepo repo)
        {
            _repo = repo;
        }
        // GET: api/Weather
        public IEnumerable<WeatherEntry> Get()
        {
            return _repo.GetLatestEntries(10);
        }

        // GET: api/Weather/5
        public IEnumerable<WeatherEntry> Get(int count)
        {
            return _repo.GetLatestEntries(count);
        }

        // POST: api/Weather
        public void Post([FromBody]WeatherEntry entry)
        {
            entry.TimeStamp = DateTime.Now;
            _repo.AddEntry(entry);
        }
    }
}
