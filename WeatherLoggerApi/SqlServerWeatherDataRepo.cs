using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WeatherLoggerApi.Models;

namespace WeatherLoggerApi
{
    public class SqlServerWeatherDataRepo : IWeatherDataRepo
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["mmt"].ConnectionString;
        public List<WeatherEntry> GetLatestEntries(int count)
        {
            var cmd = new SqlCommand(@"Select top (@count) * From WeatherEntries Order By Timestamp Desc", new SqlConnection(_connectionString));
            cmd.Parameters.Add(new SqlParameter("@count", count));
            cmd.Connection.Open();
            var dr = cmd.ExecuteReader();
            var ret = new List<WeatherEntry>();
            while (dr.Read())
            {
                ret.Add(new WeatherEntry
                {
                    Humidity = dr["Humidity"] as string,
                    Pressure = dr["Pressure"] as string,
                    RainGauge = dr["RainGauge"] as string,
                    SoilMoisture = dr["SoilMoisture"] as string,
                    SoilTemperature = dr["SoilTemperature"] as string,
                    Temperature = dr["Temperature"] as string,
                    TimeStamp = (DateTime)dr["TimeStamp"],
                    WindDirection = dr["WindDirection"] as string,
                    WindSpeed = dr["WindSpeed"] as string,
                });
            }
            cmd.Connection.Close();
            return ret;
        }
        public void AddEntry(WeatherEntry entry)
        {
            var cmd = new SqlCommand(@"Insert Into WeatherEntries (Temperature, Humidity, Pressure, RainGauge, SoilMoisture, SoilTemperature, TimeStamp, WindDirection, WindSpeed) Values (@Temperature, @Humidity, @Pressure, @RainGauge, @SoilMoisture, @SoilTemperature, @TimeStamp, @WindDirection, @WindSpeed)", new SqlConnection(_connectionString));
            cmd.Parameters.Add(new SqlParameter("@Temperature", entry.Temperature));
            cmd.Parameters.Add(new SqlParameter("@Humidity", entry.Humidity));
            cmd.Parameters.Add(new SqlParameter("@Pressure", entry.Pressure));
            cmd.Parameters.Add(new SqlParameter("@RainGauge", entry.RainGauge));
            cmd.Parameters.Add(new SqlParameter("@SoilMoisture", entry.SoilMoisture));
            cmd.Parameters.Add(new SqlParameter("@SoilTemperature", entry.SoilTemperature));
            cmd.Parameters.Add(new SqlParameter("@TimeStamp", entry.TimeStamp));
            cmd.Parameters.Add(new SqlParameter("@WindDirection", entry.WindDirection));
            cmd.Parameters.Add(new SqlParameter("@WindSpeed", entry.WindSpeed));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}