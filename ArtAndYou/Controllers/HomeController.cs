using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Newtonsoft.Json;
using ArtAndYou.Models;

namespace ArtAndYou.Controllers
{
    public class HomeController : Controller
    {
        //Walters syntax: http://api.thewalters.org/v1/objects?apikey=<your_api_key> 
        //Current API Key : xjygRMZElaE19rvIajAWGuBCY05UUFdP9GsaiCDNybj2DKEMi3HNdpC3Yl8RG5jW

        string size = "?height=300&width=300";
        string urlHeader = "http://api.harvardartmuseums.org";

        string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";

        public ActionResult Portfolio()
        {
            //string param = "/object?person=33430";
            string param = "/object?classification=Photographs&hasimage=1";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            ViewBag.ObjectID00 = o["records"][0]["objectid"];
            ViewBag.ObjectID01 = o["records"][1]["objectid"];
            ViewBag.ObjectID02 = o["records"][2]["objectid"];
            ViewBag.ObjectID03 = o["records"][3]["objectid"];
            ViewBag.ObjectID04 = o["records"][4]["objectid"];
            ViewBag.ObjectID05 = o["records"][5]["objectid"];
            ViewBag.ObjectID06 = o["records"][6]["objectid"];
            ViewBag.ObjectID07 = o["records"][7]["objectid"];
            ViewBag.ObjectID08 = o["records"][8]["objectid"];
            ViewBag.ObjectID09 = o["records"][9]["objectid"];

            //string portfolio = "";
            //int i = 0;
            //for (i = 0; i < 10; i++)
            //{
            //    portfolio += o["records"][i]["objectid"] + " ";
            //}
            //ViewBag.ObjectID = portfolio;
            return View();
        }

        public ActionResult Image()
        {
            string param = "/object?person=33430";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);
            //ViewBag.ApiText = o["url"];

            //for use with one image:
            ViewBag.ApiText = o["records"][0]["images"][0]["baseimageurl"] + size;
            return View();
        }

        public ActionResult Data(Queries q)
        {
            //string call = q.SearchURL;
            //HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            //HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org/object?aggregation={records:{people:{culture:American}}}" + APIkey);

            //HttpWebRequest request = WebRequest.CreateHttp("\"" + call + "\"");
            //request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader rd = new StreamReader(response.GetResponseStream());
            //string ApiText = rd.ReadToEnd();
            //JObject o = JObject.Parse(ApiText);
            //ViewBag.ApiText = o["url"];
            //ViewBag.search = call;
            //for use with one image:
            //ViewBag.ApiText = o["images"][0]["baseimageurl"] + size;
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Medium()
        {
            return View();
        }
        public ActionResult Choice(Medium M)
        {
            ViewBag.Name = M.firstName;
            return View(M.medium);
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}