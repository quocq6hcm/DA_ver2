using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA_ShoesOnlineStore.Models;

namespace DA_ShoesOnlineStore.Controllers
{
    public class ProductController : Controller
    {

        Models.SHOESWebSiteEntities _db = new Models.SHOESWebSiteEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Single(int sp)
        {
            SANPHAM sp1 = _db.SANPHAMs.SingleOrDefault(n => n.MaSP == sp);
            if (sp1 == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp1);
        }
        
    }
}