﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace API.model
{
    public class OpenWeatherMapProxy
    {

        public async static Task<RootObject> getWeather(string city)
        {
            var http = new HttpClient();

            var url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=57f70882c70faf2419d9157c4a0ef71a", city);
            var response = await http.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var data = (RootObject)serializer.ReadObject(ms);

            return data;

        }
    }
    [DataContract]
    public class Coord
    {
        [DataMember]
        public string city { get; set; }

    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember]
        public double temp { get; set; }

        [DataMember]
        public double pressure { get; set; }

        [DataMember]
        public double humidity { get; set; }

        [DataMember]
        public double temp_min { get; set; }

        [DataMember]
        public double temp_max { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }

        [DataMember]
        public double deg { get; set; }
    }



    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }

    [DataContract]
    public class Sys
    {

        [DataMember]
        public int type { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public double message { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public int sunrise { get; set; }

        [DataMember]
        public int sunset { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }

        [DataMember]
        public List<Weather> weather { get; set; }

        [DataMember]
        public string @base { get; set; }

        [DataMember]
        public Main main { get; set; }

        [DataMember]
        public Wind wind { get; set; }

        [DataMember]
        public Clouds clouds { get; set; }

        [DataMember]
        public int dt { get; set; }

        [DataMember]
        public Sys sys { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int cod { get; set; }
    }

}
