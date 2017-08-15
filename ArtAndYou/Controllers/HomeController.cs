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
using System.Data.SqlClient; //need for reading SQL database
using System.Text; //need for code reading SQL database

namespace ArtAndYou.Controllers
{
    
    public class HomeController : Controller
    {
        string size = "?width=300";
        string urlHeader = "http://api.harvardartmuseums.org";
        string APIkey = "&apikey=db4038a0-79da-11e7-aa25-e32c9c02c857";

        public ActionResult Show4Explore(Input i)
        {
            Queries q = new Queries();
            string portfolio = q.ImageSearch(i.Classification, i.Culture, i.Century);
            ViewBag.ObjectID = portfolio;
            return View("Show4Survey");
        }

        public ActionResult Show4Survey()
        {
            string name = "";
            string classification = "";
            string culture = "";
            string century = "";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "artserverfinal.database.windows.net";
            builder.UserID = "finalproject";
            builder.Password = "Teamproject1";
            builder.InitialCatalog = "ArtInfo";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 1 [ID], [Name], [Classification], [Century], [Culture] ");
                sb.Append("FROM [dbo].[UserInfo] ");
                sb.Append("ORDER BY [ID] DESC");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(1);
                            classification = reader.GetString(2);
                            century = reader.GetString(3);
                            culture = reader.GetString(4);
                        }
                    }
                }
            }
            Queries q = new Queries();
            string portfolio = q.ImageSearch(classification, culture, century);
            ViewBag.ObjectID = portfolio;
            ViewBag.Name = name;
            return View();
        }

        public ActionResult Portfolio(/*Input i*/)
        {
            string name = "";
            string classification = "";
            string culture = "";
            string century = "";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "artserverfinal.database.windows.net";
            builder.UserID = "finalproject";
            builder.Password = "Teamproject1";
            builder.InitialCatalog = "ArtInfo";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 1 [ID], [Name], [Classification], [Century], [Culture] ");
                sb.Append("FROM [dbo].[NewTestTable] ");
                sb.Append("ORDER BY [ID] DESC");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(1);
                            classification = reader.GetString(2);
                            century = reader.GetString(3);
                            culture = reader.GetString(4);
                            
                        }
                    }
                }
            }

            //string classification = "Photographs";
            //string culture = "American";
            //string century = "20th%20century";

            //string classification = i.Classification;
            //string culture = i.Culture;
            //string century = i.Century;

            Queries q = new Queries();
            string portfolio = q.ImageSearch(classification, culture, century);
            ViewBag.ObjectID = portfolio;
            ViewBag.Name = name;
            return View();
        }

        public ActionResult Image() //for use with one image:
        {
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

        public ActionResult Data(Queries q)
        {
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

        public ActionResult AfterTestSurvey(Input i)
        {
            int currentID = 0;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "artserverfinal.database.windows.net";
            builder.UserID = "finalproject";
            builder.Password = "Teamproject1";
            builder.InitialCatalog = "ArtInfo";
            //--------------
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 1 [ID]");
                sb.Append("FROM [dbo].[NewTestTable] ");
                sb.Append("ORDER BY [ID] DESC");
                String sql = sb.ToString();

                using (SqlCommand read = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = read.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //currentID = int.Parse(reader.GetString(0));
                            currentID = reader.GetInt32(0);
                        }
                    }
                }
                connection.Close();
            }
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                using (SqlCommand update = connection.CreateCommand())
                    {
                update.CommandText = "UPDATE [dbo].[NewTestTable] SET [Classification] = '" + i.Classification + "', [Century] = '" + i.Century + "' WHERE [ID] = '" + currentID + "';";
                        connection.Open();
                        update.ExecuteNonQuery();
                        connection.Close();
                    }
                return View();
            }

        public ActionResult TestSurvey(GetName n)
        {
            string name = n.Name;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "artserverfinal.database.windows.net";
            builder.UserID = "finalproject";
            builder.Password = "Teamproject1";
            builder.InitialCatalog = "ArtInfo";
            //--------------
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                int currentID = 0;

                connection.Open();
                //StringBuilder sb = new StringBuilder();
                //sb.Append("SELECT TOP 1 [ID], [Name], [Classification], [Culture], [Century] ");
                //sb.Append("FROM [dbo].[NewTestTable] ");
                //sb.Append("ORDER BY [ID] DESC");
                //String sql = sb.ToString();

                //using (SqlCommand read = new SqlCommand(sql, connection))
                //{
                //    using (SqlDataReader reader = read.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            currentID = int.Parse(reader.GetString(0));
                //        }
                //    }
                //}
                //connection.Close();
                //}
                //---------------------
                //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                using (SqlCommand update = connection.CreateCommand())
                {
                    update.CommandText = "INSERT INTO [dbo].[NewTestTable] ([Name], [Classification], [Century], [Culture]) VALUES ('" + n.Name + "', '', '', '')";
                    //connection.Open();
                    update.ExecuteNonQuery();
                    connection.Close();
                }
                ViewBag.Name = n.Name;
                return View();
            }
        }

        public ActionResult GetName()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Art N You.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We Love Bringing Art To You";
            return View();
        }

        public ActionResult Query()
        {
            return View();
        }

        // THE FOLLOWING RETURN JSON DATA FOR HELP WITH NOMENCLATURE WHEN BUILDING QUERIES
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

        //public ActionResult CreateName20([Bind(Include = "ID,Name")] UserInfo UserInfo)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.UserInfoes.Add(UserInfo);
        //        db.SaveChanges();
        //        return RedirectToAction("SurveyQ1Classification", "Survey");
        //    }

        //    return View("Contact");
        //}
    }
}