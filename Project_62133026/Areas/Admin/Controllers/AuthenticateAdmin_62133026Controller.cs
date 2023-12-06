using Project_62133026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_62133026.Areas.Admin.Controllers
{
    public class AuthenticateAdmin_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();
        [HttpGet]
        // GET: Authenticate_62133026
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return RedirectToAction("Index", "Dashboard_62133026");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            var taikhoan = db.TaiKhoans.Find(email);
            if (taikhoan == null)
            {
                ViewBag.Mess = "Email không tồn tại!";
                return View();
            }
            else if (!taikhoan.nhanVien)
            {
                ViewBag.Mess = "Email không tồn tại!";
                return View();
            }
            else
            {   
                if (taikhoan.matKhau != password)
                {
                    ViewBag.Mess = "Mật khẩu không đúng. Vui lòng thử lại!";
                    ViewBag.email = email;
                    return View();
                }
                else
                {
                    var nv = db.NhanViens.Where(NhanVien => NhanVien.email == email).First();
                    Session["admin"] = nv.tenNV;
                    return RedirectToAction("Index", "Dashboard_62133026");
                }
            }
            

        }
        public ActionResult Logout()
        {
            Session.Remove("admin");
            return RedirectToAction("Index", "AuthenticateAdmin_62133026");

        }
    }
}