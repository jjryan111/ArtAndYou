using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;

namespace ArtAndYou.Models
{
    public class Queries
    {
        //constructor; created by default if not here.
        public Queries() { }

        public string ImageSearch(string classification, string culture, string century)
        {
            string classSpec = classification;
            string cultureSpec = culture;
            string centurySpec = century;
            string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";
            string portfolio = "";
            string photoSize = "?width=300";
            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org/object?classification=" + classSpec + "&culture=" + cultureSpec + "&century=" + centurySpec + "&sort=random&hasimage=1&size=100" + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    portfolio += o["records"][i]["images"][0]["baseimageurl"] + photoSize + ",";
                }
                catch (Exception)
                {
                    portfolio += "";
                }
            }
            return portfolio;
        }

    public class Location
    {
        [Required]
        [Range(37, 41)]
        public double Latitude { get; set; }
        [Required]
        [Range(-109, -102)]
        public double Longitude { get; set; }
    }
    }
}