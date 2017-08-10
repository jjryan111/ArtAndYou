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
using System.Data.Sql;

namespace ArtAndYou.Controllers
{
    public class HomeController : Controller
    {
        private ArtInfoEntities1 db = new ArtInfoEntities1();

        public ActionResult CreateName20([Bind(Include = "ID,Name")] UserInfo UserInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoes.Add(UserInfo);
                db.SaveChanges();
                return RedirectToAction("SurveyQ1Classification", "Survey");
            }

            return View("Contact");
        }
            string size = "?width=300";
        string urlHeader = "http://api.harvardartmuseums.org";

        string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";

        public ActionResult Portfolio(Input i)
        {
            //string classification = "Photographs";
            //string culture = "American";
            //string century = "20th%20century";

            string classification = i.Classification;
            string culture = i.Culture;
            string century = i.Century;

            Queries q = new Queries();
            string portfolio = q.ImageSearch(classification, culture, century);
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

        public ActionResult TextileInfo()
        {
            string param = "/object?classification=Textile%20Arts&size=100&sort=century&aggregation={%22by%20century%22:{%22terms%22:{%22field%22:%22century%22}}}";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);
            ViewBag.ApiText = o;
            string textile = "";
            int i = 0;
            //textile = "Century: " + o["aggregations"]["by century"]["buckets"][i]["key"] + ",";
            for (i = 0; i < 100; i++)
            {
                try
                {
                    textile += "Century: " + o["aggregations"]["by century"]["buckets"][i]["key"] + ",";
                }
                catch (Exception)
                {
                    textile += "";
                }
            }
            ViewBag.Textiles = textile;
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
            string param = "/century?sort=objectcount&sortorder=desc&size=100";

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
                    century += "ID: " + o["records"][i]["centuryid"] + " Name: " + o["records"][i]["name"] + " Qty: " + o["records"][i]["objectcount"] + ",";
                }
                catch (Exception)
                {
                    century += "";
                }
            }
            ViewBag.Centuries = century;
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
            ViewBag.Message = "We Love Bringing Art In You";

            return View();
        }

        public ActionResult Query()
        {
            return View();
        }
    }
}