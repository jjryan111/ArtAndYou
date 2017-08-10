using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtAndYou.Controllers;
using ArtAndYou.Models;
using System.Net;

namespace ArtAndYou.Controllers
{
    public class SurveyController : Controller
    {
        public string name;
        public string cent;
        public string cult;
        public string classification;

        string thing = "";
        private ArtInfoEntities1 db = new ArtInfoEntities1();

     
        // GET: UserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }
        public  ActionResult Choice1(Survey M)
        {
            string concat = M.ConCatChoice(M.question, M.classification, M.cent);
            return View(concat);
        }

        // GET: Survey
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SurveyQ3PaintCult()
        {
            return View();
        }
        public ActionResult SurveyQ2PaintCent()
        {
            return View();
        }

        public ActionResult SurveyQ1Classification()
        {
            return View();
        }
    }
}