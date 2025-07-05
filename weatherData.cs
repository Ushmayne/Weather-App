using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//a class to hold the weather data
// This class is used to deserialize the JSON response from the OpenWeatherMap API
// It contains properties that match the structure of the JSON response
// The properties are public and have getters and setters to allow for serialization and deserialization

namespace Weather_App
{
    public class weatherData
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public int sea_level { get; set; }
            public int grnd_level { get; set; }
        }

        public class wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
        }

        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
        }

        public class root
        {
            public coord coord { get; set; }
            public List<weather> weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }
            public sys sys { get; set; }
            
        }

    }
}