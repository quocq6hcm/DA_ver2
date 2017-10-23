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

        Repositories.UserDAO userDAO = new Repositories.UserDAO();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["Cart"] = null;
            var model = _db.SANPHAMs.ToList();
            return View(model);
        }

        public ActionResult Filter(string txtSearch)
        {
            if(string.IsNullOrEmpty(txtSearch))
            {
                return Index();
            }
            else
            {
                var model = _db.SANPHAMs.Where(a => a.TenSP.Contains(txtSearch)).ToList();
                return View("Index", model);
            }
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

        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(Models.NguoiDung newUser)
        {
            try
            {
                if(ModelState.IsValid)
                { 
                    userDAO.AddUser(newUser);
                   
                    return Redirect("http://localhost:54763/Home/Register#signup");
                }
                else
                {
                    ModelState.AddModelError("AddError", "Thêm người dùng thất bại");
                    return View();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("AddError","Thêm người dùng thất bại");
                return View();

            }
           
            
        }

        public ActionResult UserNotFound()
        {
            return View("LoginError");
        }

        [HttpPost]
        public ActionResult Login(Models.NguoiDung loginUser)
        {
            try
            {
                var check = userDAO.LoginUser(loginUser);
                if (check == null)
                {
                    return RedirectToAction("UserNotFound");
                }
                else
                {
                    
                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            { 
                return RedirectToAction("UserNotFound");
            }
           
        }

        public ActionResult LogOut()
        {
            userDAO.Logout();
            return RedirectToAction("Index");
        }
    }
}