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
            double lon { get; set; }
            double lat { get; set; }
        }
        public class weather
        {
            string main { get; set; }
            string description { get; set; }
            string icon { get; set; }
        }
        public class main
        {
            double temp { get; set; }
            double feels_like { get; set; }
            double temp_min { get; set; }
            double temp_max { get; set; }
            int pressure { get; set; }
            int humidity { get; set; }
            int sea_level { get; set; }
            int grnd_level { get; set; }
        }

        public class wind
        {
            double speed { get; set; }
            int deg { get; set; }
        }

        public class sys
        {
            long sunrise { get; set; }
            long sunset { get; set; }
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