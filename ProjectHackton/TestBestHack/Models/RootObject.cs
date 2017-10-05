using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBestHack.Models
{
    public class RootObject
    {
        public string status { get; set; }
        public List<Source> sources { get; set; }
    }
}