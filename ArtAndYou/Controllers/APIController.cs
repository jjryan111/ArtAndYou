using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient; //need for reading SQL database
using System.Text; //need for code reading SQL database
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ArtAndYou.Controllers
{
    public class APIController : Controller
    {
        string size = "?width=300";
        string urlHeader = "http://api.harvardartmuseums.org";
        string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";

        // GET: API
        public ActionResult Index()
        {
            return View();
        }

        // THE FOLLOWING RETURN ASI JSON DATA FOR HELP WITH NOMENCLATURE WHEN BUILDING QUERIES
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

        public ActionResult CultureInfo()
        {
            string param = "/culture?sort=objectcount&sortorder=desc&size=100";

            HttpWebRequest request = WebRequest.CreateHttp("http://api.harvardartmuseums.org" + param + APIkey);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string ApiText = rd.ReadToEnd();
            JObject o = JObject.Parse(ApiText);

            string culture = "";
            int i = 0;
            for (i = 0; i < 100; i++)
            {
                try
                {
                    culture += "ID: " + o["records"][i]["culture"] + " Name: " + o["records"][i]["name"] + " Qty: " + o["records"][i]["objectcount"] + ",";
                }
                catch (Exception)
                {
                    culture += "";
                }
            }
            ViewBag.Cultures = culture;
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
    }
}