using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace SaveMeTimeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestRoutesDrivingController : ControllerBase
    {
        private string apiKey = Environment.GetEnvironmentVariable("ApiKey");

        [HttpGet]
        public string Get(string wp0, string wp1, string optmz)
        {
            string url = @"https://dev.virtualearth.net/REST/V1/Routes/Driving";
            var param = new Dictionary<string, string>() {
                { "wp.0", wp0 },
                { "wp.1", wp1 },
                { "optmz", optmz },
                { "key", apiKey}
                 };
            var paramstring = string.Join(Environment.NewLine, param);
            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newUrl);
            var response = request.GetResponse().GetResponseStream();
            var reader = new StreamReader(response);
            return reader.ReadToEnd();
        }
    }
}
