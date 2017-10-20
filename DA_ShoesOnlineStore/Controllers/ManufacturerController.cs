using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DA_ShoesOnlineStore.Controllers
{
    public class ManufacturerController : Controller
    {


        Models.SHOESWebSiteEntities _db = new Models.SHOESWebSiteEntities();
        //// GET: Manufacturer
        public ActionResult Index()
        { 
            var model = _db.NHACUNGCAPs.ToList();
            return View(model);
        }
    }
}