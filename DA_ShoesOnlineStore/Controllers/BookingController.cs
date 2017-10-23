using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_ShoesOnlineStore.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}