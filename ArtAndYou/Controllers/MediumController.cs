using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtAndYou.Models;
using ArtAndYou.Controllers;
using System.Data.Entity;
using System.Data.Sql;
using System.Net;
using System.Data.SqlClient; //need for reading SQL database
using System.Text;

namespace ArtAndYou.Controllers

{
    public class MediumController : Controller
    {
        private ArtInfoEntities1 db = new ArtInfoEntities1();
        public string name;
        public string medium;
        // GET: Medium
        public ActionResult Index()
        {
            //List <Survey1> thing = M.Details("5");
            //ViewBag.thing2 = thing[1].ToString();
            //ViewBag.Thing3 = "thing";
            return View();
        }
        public ActionResult Medium()
        {
            return View();
        }
        //public ActionResult Choice(Medium M)
        //{
        //    this.name = M.firstName;
        //    this.medium = M.medium;
        //    ViewBag.Name = name;
        //    return View(M.medium);
        //}
        public ActionResult Q1Genre()
        {

            return View();
        }
        public ActionResult Q2Category(string name)
        {
            ViewBag.Thing = "Hello World";
            ViewBag.Name = this.name;
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ClassEdit([Bind(Include = "ID,Classification")] UserInfo userInfo, Survey1 clsurv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                clsurv.Medium = userInfo.Classification;
                //userInfo = db.UserInfoes.Find(ID);
                db.UserInfoes.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }
        public ActionResult TestSurvey(Survey1 n)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "artserverfinal.database.windows.net";
            builder.UserID = "finalproject";
            builder.Password = "Teamproject1";
            builder.InitialCatalog = "ArtInfo";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE [dbo].[HelgesonTestTable] SET Classification = '" + n.Medium + "' WHERE ID =(SELECT MAX(ID) FROM [dbo].[HelgesonTestTable])";

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            ViewBag.Name = n.Medium;
            return View("../Survey2/Index");
        }
        public ActionResult TestSurvey2(Survey1 n)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "artserverfinal.database.windows.net";
            builder.UserID = "finalproject";
            builder.Password = "Teamproject1";
            builder.InitialCatalog = "ArtInfo";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE [dbo].[HelgesonTestTable] SET Century = '" + n.Year + "' WHERE ID =(SELECT MAX(ID) FROM [dbo].[HelgesonTestTable])";

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            ViewBag.Name = n.Year;
            return View();
        }
        public ActionResult Show4Survey1(Survey1 n)
        {
            int ID = 0;
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
                sb.Append("SELECT TOP 1 [ID], [Name], [Classification], [Culture], [Century] ");
                sb.Append("FROM [dbo].[UserInfo] ");
                sb.Append("ORDER BY [ID] DESC");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = reader.GetInt32(0);
                            name = reader.GetString(1);
                            //classification = reader.GetString(2);
                            //culture = reader.GetString(3);
                            //century = reader.GetString(4);
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE [dbo].[UserInfo] SET Classification='" + n.Medium + "' WHERE ID=" + ID;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            ViewBag.Name = n.Year;
            return RedirectToAction("Index", "Survey2");

            //return View("../Survey2/Index");
            //Queries q = new Queries();
            //string portfolio = q.ImageSearch(classification, culture, century);
            //ViewBag.ObjectID = portfolio;
            //ViewBag.Name = name;
            //return View();
        }
        public ActionResult Show4Survey2(Survey2 n)
        {
            int ID = 0;
            //string name = "";
            //string classification = "";
            //string culture = "";
            //string century = "";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "artserverfinal.database.windows.net";
            builder.UserID = "finalproject";
            builder.Password = "Teamproject1";
            builder.InitialCatalog = "ArtInfo";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 1 [ID], [Name], [Classification], [Culture], [Century] ");
                sb.Append("FROM [dbo].[UserInfo] ");
                sb.Append("ORDER BY [ID] DESC");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = reader.GetInt32(0);
                            name = reader.GetString(1);
                            //classification = reader.GetString(2);
                            //culture = reader.GetString(3);
                            //century = reader.GetString(4);
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE [dbo].[UserInfo] SET Century='" + n.Year + "' WHERE ID=" + ID;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            ViewBag.Name = n.Year;
            return RedirectToAction("Index", "Survey3");
            //Queries q = new Queries();
            //string portfolio = q.ImageSearch(classification, culture, century);
            //ViewBag.ObjectID = portfolio;
            //ViewBag.Name = name;
            //return View();
        }
        public ActionResult Show4Survey3(Survey3 n)
        {
            int ID = 0;
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
                sb.Append("SELECT TOP 1 [ID], [Name], [Classification], [Culture], [Century] ");
                sb.Append("FROM [dbo].[UserInfo] ");
                sb.Append("ORDER BY [ID] DESC");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = reader.GetInt32(0);
                            name = reader.GetString(1);
                            //classification = reader.GetString(2);
                            //culture = reader.GetString(3);
                            //century = reader.GetString(4);
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE [dbo].[UserInfo] SET Culture='" + n.Genre + "' WHERE ID=" + ID;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            ViewBag.Name = n.Genre;
            return RedirectToAction("Index", "Survey3");
        }
    }
}