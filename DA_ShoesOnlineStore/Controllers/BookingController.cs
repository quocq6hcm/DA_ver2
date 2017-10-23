using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_ShoesOnlineStore.Controllers
{
    public class BookingController : Controller
    {
        public static IEnumerable<CartItem> cart = new List<CartItem>();
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            
            
          
            
            return View(cart);
        }

        public ActionResult AddToCart(int MaSP)
        {
            //cart.Add(MaSP);
            //System.Web.HttpContext.Current.Session.Add("Cart", cart);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public string showSession()
        {
            List<int> myList = new List<int>();
            myList = (List<int>)System.Web.HttpContext.Current.Session["Cart"];
            return myList.Count().ToString();
        }

        
    }
    
    public class CartItem
    {
        public int MaSP { get; set; }

        public string AnhBia { get; set; }

        public string DonGia { get; set; }

        public String TenSP { get; set; }

        public string MoTa { get; set; }
    }
}