using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SaveMeTimeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BingSourceController : ControllerBase
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("ApiKey");
        [HttpGet]
        public string Get()
        {
            string url = @"https://www.bing.com/api/maps/mapcontrol?callback=GetMap&key=" + apiKey;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            var response = request.GetResponse().GetResponseStream();  
            var reader = new StreamReader(response);
            return reader.ReadToEnd();
        }
    }
}
