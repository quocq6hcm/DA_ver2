using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_ShoesOnlineStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Models.SHOESWebSiteEntities _db = new Models.SHOESWebSiteEntities();

       

        public Models.NguoiDung GetAdmin()
        {
            var UserId = Session["UserId"];
            var role = Session["Role"];
            return _db.NguoiDungs.Find(UserId);
        }



        public ActionResult Index()
        {
            
            
            if (GetAdmin() != null)
            {
                
                return View(GetAdmin());
            }
            else
                return View();
        }

        public ActionResult AddProduct()
        {
            return View(GetAdmin());
        }
    }
}