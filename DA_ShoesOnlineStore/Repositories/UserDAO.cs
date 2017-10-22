using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_ShoesOnlineStore.Repositories
{
    public class UserDAO
    {
        Models.SHOESWebSiteEntities _db = new Models.SHOESWebSiteEntities();

        public void AddUser(Models.NguoiDung newUser)
        {
            newUser.role = 0;
            newUser.NamSinh = null;

            _db.NguoiDungs.Add(newUser);
            _db.SaveChanges();
            return;
        }

        public Models.NguoiDung LoginUser(Models.NguoiDung loginUser)
        {
            var u = _db.NguoiDungs.SingleOrDefault(user => user.TaiKhoan.Equals(loginUser.TaiKhoan));
            if (u != null)
            {
                if (u.MatKhau.Equals(loginUser.MatKhau))
                {
                    HttpContext.Current.Session["User"] = u.HoTen;
                    return u;
                }
                    
            }
            return null;
        }

        public void Logout()
        {
            HttpContext.Current.Session["User"] = null;
        }
    }
}