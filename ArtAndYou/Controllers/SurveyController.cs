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
            //this.classification = M.classification;
            return View(M.classification);
        }

        public ActionResult SurveyQ2SculptCent()
        {
            return View();
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

        public ActionResult SurveyQ3SculptCult()
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

        public ActionResult SurveyQ3PhotoCult()
        {
            return View();
        }
    }
}