using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherInfo
{
    public class MapBoxResponse
    {
        public string type { get; set; }
        public string[] query { get; set; }
        public Feature[] features { get; set; }
    }

    public class Feature
    {
        public string id { get; set; }
        public string type { get; set; }
        public string[] place_type { get; set; }
        public float relevance { get; set; }
        public string address { get; set; }
        public string text { get; set; }
        public string place_name { get; set; }
        public float[] center { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
        public Context[] context { get; set; }
        public float[] bbox { get; set; }
        public string matching_text { get; set; }
        public string matching_place_name { get; set; }
    }

    public class Properties
    {
        public string accuracy { get; set; }
        public string foursquare { get; set; }
        public bool landmark { get; set; }
        public string address { get; set; }
        public string category { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
        public bool interpolated { get; set; }
        public bool omitted { get; set; }
    }

    public class Context
    {
        public string id { get; set; }
        public string text { get; set; }
        public string wikidata { get; set; }
        public string short_code { get; set; }
    }
}
