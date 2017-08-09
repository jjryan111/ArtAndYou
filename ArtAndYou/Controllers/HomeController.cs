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
        //main access page for Walters account: http://api.thewalters.org/sgaccount/index
        //All together, now: http://api.thewalters.org/v1/objects?apikey=xjygRMZElaE19rvIajAWGuBCY05UUFdP9GsaiCDNybj2DKEMi3HNdpC3Yl8RG5jW

        string size = "?height=300&width=300";
        string urlHeader = "http://api.harvardartmuseums.org";

        string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";

        public ActionResult Portfolio()
        {
            string sampleSize = "&size=25";
            string searchParam = "/object?classification=Paintings&sort=random";
            //string param = "/object?person=33430&size=15";
            //string param = "/object?classification=Photographs&hasimage=1";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + searchParam + sampleSize + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            string portfolio = "";
            int i = 0;
            for (i = 0; i < 50; i++)
            {
                try
                {
                    portfolio += o["records"][i]["images"][0]["baseimageurl"] + "?height=300&width=300" + ",";
                }
                catch (Exception)
                {
                    portfolio += "";
                }
            }
            ViewBag.ObjectID = portfolio;
            return View();
        }

        public ActionResult Image()
        {
            //for use with one image:

            string param = "/object?person=33430";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            ViewBag.ApiText = o["records"][0]["images"][0]["baseimageurl"] + size;
            return View();
        }

        public ActionResult ClassificationInfo()
        {
            string param = "/classification?sort=objectcount&sortorder=desc&size=100";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            string classification = "";
            int i = 0;
            for (i = 0; i < 100; i++)
            {
                try
                {
                    classification += "ID: " + o["records"][i]["classificationid"] + " Name: " + o["records"][i]["name"] + " Qty: " + o["records"][i]["objectcount"] + ",";
                }
                catch (Exception)
                {
                    classification += "";
                }
            }
            ViewBag.Classifications = classification;
            return View();
        }

        public ActionResult CenturyInfo()
        {
            string param = "/century?sort=century&size=100";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            string century = "";
            int i = 0;
            for (i = 0; i < 100; i++)
            {
                try
                {
                    century += o["records"][i]["centuryid"] + " " + o["records"][i]["name"] + ",";
                }
                catch (Exception)
                {
                    century += "";
                }
            }
            ViewBag.century = century;
            return View();
        }

        public ActionResult Divisions()
        {
            string param = "/object?sort=division&sortorder=desc&size=100";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            string division = "";
            int i = 0;
            for (i = 0; i < 100; i++)
            {
                try
                {
                    division += "ID: " + o["records"][i]["division"] + " Name: " + o["records"][i]["name"] + " Qty: " + o["records"][i]["objectcount"] + ",";
                }
                catch (Exception)
                {
                    division += "";
                }
            }
            ViewBag.divisions = division;
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