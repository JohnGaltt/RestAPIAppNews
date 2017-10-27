using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using TestBestHack.Models;
using Newtonsoft.Json;

namespace TestBestHack.Controllers
{
    public class HomeController : Controller
    {

        public async Task<RootObject> GetData(string category)
        {
            WebRequest request = WebRequest.Create(@"https://newsapi.org/v1/sources?category=" + category + "&language=en");

            request.Method = "GET";
            request.ContentType = "application/json";

            WebResponse response = await request.GetResponseAsync();

            string answer;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();

            RootObject obj = JsonConvert.DeserializeObject<RootObject>(answer);

            return obj;
        }

        [HttpPost]
        public ActionResult Index(string category)
        {
            //string[] str = Enum.GetNames(typeof(CategoryType));

            HttpContext.Response.Headers.Add("refresh", "7200; url=" + Url.Action("Index"));

            CategoryType enumDisplayStatus = (CategoryType)Int32.Parse(category);
            string stringValue = enumDisplayStatus.ToString();

            RootObject obj =  GetData(stringValue);

            List<Source> sources = new List<Source>();

            foreach (var s in obj.sources)
            {
                sources.Add(s);
            }

            return View(sources);
        }

        [HttpGet]
        public ActionResult Index()
        {
            //HttpContext.Response.Headers.Add("refresh", "7200; url=" + Url.Action("Index"));

            RootObject obj = GetData("business");

            List<Source> sources = new List<Source>();

            foreach (var s in obj.sources)
            {
                sources.Add(s);
            }

            return View(sources);
        }
    }
}
