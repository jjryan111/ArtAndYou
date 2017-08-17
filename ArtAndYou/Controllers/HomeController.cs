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
            return View("SlideShow");
        }

        public ActionResult Show4Survey()
        {
            string[] currentUser = ReadCurrentUser();
            string name = currentUser[1];
            string classification = currentUser[2];
            string century = currentUser[3];
            string culture = currentUser[4];

            Queries q = new Queries();
            string portfolio = q.ImageSearch(classification, culture, century);
            ViewBag.ObjectID = portfolio;
            ViewBag.Name = name;
            return View("SlideShow");
        }

        public ActionResult Portfolio()
        {
            string[] currentUser = ReadCurrentUser();
            string name = currentUser[1];
            string classification = currentUser[2];
            string century = currentUser[3];
            string culture = currentUser[4];

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

        public ActionResult Index()
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

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                int currentID = 0;

                connection.Open();
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

        public string[] ReadCurrentUser()
        {
            string[] currentUser = new string[5];

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
                            currentUser[0] = reader.GetInt32(0).ToString(); //ID
                            currentUser[1] = reader.GetString(1); //name
                            currentUser[2] = reader.GetString(2); //classification
                            currentUser[3] = reader.GetString(3); //century
                            currentUser[4] = reader.GetString(4); //culture
                        }
                    }
                }
                connection.Close();
                return currentUser;
            }
        }
    }
}