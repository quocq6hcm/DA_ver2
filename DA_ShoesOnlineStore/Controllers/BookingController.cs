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
            Models.SHOESWebSiteEntities _db = new Models.SHOESWebSiteEntities();

            //for (int i = 0; i < ShoppingCart.Instance.Items.Count; i++)
            //{
            //    CartItem cartItem = ShoppingCart.Instance.Items[i];
            //    for (int j = 0; j < ShoppingCart.Instance.Items.Count; j++)
            //    {
            //        if (cartItem.MaSP.Equals(ShoppingCart.Instance.Items[j].MaSP))
            //        {
            //            ShoppingCart.Instance.Items[i].SoLuong++;
            //            ShoppingCart.Instance.RemoveItem(ShoppingCart.Instance.Items[j].MaSP);
            //        }
            //    }
            //}

            for (int i = 0; i < ShoppingCart.Instance.Items.Count; i++)
            {
                var rs = _db.SANPHAMs.Find(ShoppingCart.Instance.Items[i].MaSP);
                ShoppingCart.Instance.Items[i].TenSP = rs.TenSP;
                ShoppingCart.Instance.Items[i].DonGia = rs.GiaBan.ToString();
                ShoppingCart.Instance.Items[i].AnhBia = rs.AnhBia;
                ShoppingCart.Instance.Items[i].MoTa = rs.MoTa;
            }



            return View(ShoppingCart.Instance.Items);
        }

        public ActionResult AddToCart(int MaSP)
        {
            ShoppingCart.Instance.AddItem(MaSP);

            //cart.Add(cartItem);
            //System.Web.HttpContext.Current.Session.Add("Cart", cart);
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult Remove(int MaSP)
        {
            ShoppingCart.Instance.RemoveItem(MaSP);
            // ShoppingCart.Instance.Items.Remove(ShoppingCart.Instance.Items.ToList().Find());
            CartItem ci = new CartItem(MaSP);
            var item = ShoppingCart.Instance.Items.SingleOrDefault( a => a.MaSP.Equals(ci.MaSP));
            ShoppingCart.Instance.Items.Remove(item);
            return View("Checkout", ShoppingCart.Instance.Items);
        }

        public string showSession()
        {
            Models.SHOESWebSiteEntities _db = new Models.SHOESWebSiteEntities();

            for (int i = 0; i < ShoppingCart.Instance.Items.Count; i++)
            {
                CartItem cartItem = ShoppingCart.Instance.Items[i];
                for ( int j = 0; j < ShoppingCart.Instance.Items.Count; j++ )
                {
                    if (cartItem.MaSP.Equals(ShoppingCart.Instance.Items[j].MaSP))
                    {
                        ShoppingCart.Instance.Items[i].SoLuong++;
                        ShoppingCart.Instance.RemoveItem(ShoppingCart.Instance.Items[j].MaSP);
                    }
                }
            }

            for (int i = 0; i < ShoppingCart.Instance.Items.Count; i++)
            {
                var rs = _db.SANPHAMs.Find(ShoppingCart.Instance.Items[i].MaSP);
                ShoppingCart.Instance.Items[i].TenSP = rs.TenSP;
                ShoppingCart.Instance.Items[i].DonGia = rs.GiaBan.ToString();
                ShoppingCart.Instance.Items[i].AnhBia = rs.AnhBia;
                ShoppingCart.Instance.Items[i].MoTa = rs.MoTa;
            }

            
            return ShoppingCart.Instance.Items[1].TenSP.ToString();
        }

        
    }
    
    
    public class CartItem
    {
        public CartItem(int MaSP)
        {
            this.MaSP = MaSP;
        }
        public bool Equals(CartItem item)
        {
            return item.MaSP == this.MaSP;
        }
        public int MaSP { get; set; }

        public string AnhBia { get; set; }

        public string DonGia { get; set; }

        public String TenSP { get; set; }

        public string MoTa { get; set; }

        public int SoLuong { get; set; }
    }

    public class ShoppingCart
    {
        public List<CartItem> Items { get;  set; }

        public static readonly ShoppingCart Instance;

        static ShoppingCart()
        {
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                Instance = new ShoppingCart();
                Instance.Items = new List<CartItem>();
                System.Web.HttpContext.Current.Session["Cart"] = Instance;
            }
            else
            {
                Instance = (ShoppingCart)HttpContext.Current.Session["Cart"];
            }
        }

       
        public void AddItem(int MaSP)
        {
            var option = 0;
            

            for ( int i = 0; i < Items.Count; i++)
            {
                if (Items[i].MaSP.Equals(MaSP))
                {
                    Items[i].SoLuong++;
                    option = 1;
                }
            }

            if (option == 0)
            {
                CartItem newItem = new CartItem(MaSP);
                newItem.SoLuong = 1;
                Items.Add(newItem);
            }
            //if (Items.Contains(newItem))
            //{
            //    foreach (CartItem item in Items)
            //    {
            //        if (item.Equals(newItem))
            //        {
            //            item.SoLuong++;
            //            return;
            //        }
            //    }
            //}
            //else
            //{
            //    newItem.SoLuong = 1;
            //    Items.Add(newItem);
            //}
        }


        public void SetItemQuantity(int productId, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.SoLuong = quantity;
                    return;
                }
            }
        }

        public void RemoveItem(int MaSP)
        {
            CartItem removedItem = new CartItem(MaSP);
            Items.Remove(removedItem);
        }

    }
}