using DA_ShoesOnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_ShoesOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        Models.SHOESWebSiteEntities _db = new Models.SHOESWebSiteEntities();
        public ActionResult Index()
        {
            var model = _db.SANPHAMs.ToList();
            return View(model);
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