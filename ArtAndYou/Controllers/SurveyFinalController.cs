using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient; //need for reading SQL database
using System.Text;
using ArtAndYou.Models;
namespace ArtAndYou.Controllers
{
    public class SurveyFinalController : Controller
    {
        // GET: SurveyFinal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show4Survey1(Survey1 n)
        {
            int ID = 0;
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
            //ViewBag.Name = n.Year;
            return RedirectToAction("Index", "Survey2");
        }
        public ActionResult Show4Survey2(Survey2 n)
        {
            int ID = 0;
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
        }
        public ActionResult Show4Survey3(Survey3 n)
        {
            int ID = 0;
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
            return RedirectToAction("Show4Survey", "Home");
        }
    }
}