using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace ArtAndYou.Models
{
    public class Queries
    {
        public Queries() { }
        public string ImageSearch(string classification)
        {
            string classSpec = classification;          
            string searchParam = "&culture=Japanese&sort=random";
            string hasImage = "&hasimage=1";
            string sampleSize = "&size=100";
            string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";
            string portfolio = "";
            string photoSize = "?height=300&width=300";
            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org/object?classification=" + classSpec + searchParam + hasImage + sampleSize + APIkey);
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

        //public string SearchURL = urlHeader + param + APIkey;

        //public string buildURL(string parameter)
        //{
        //    string url = urlHeader + param + APIkey;
        //    return url;
        //}
    }
}