using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBestHack.Models
{
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public CategoryType Category { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public UrlsToLogos urlsToLogos { get; set; }
        public List<string> sortBysAvailable { get; set; }
    }

    public enum CategoryType
    {
        business,
        entertainment,
        gaming,
        general,
        music,
        politics,
        sport,
        technology
    }
}