using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_62133026.Models;

namespace Project_62133026.Controllers
{
    public class Authenticate_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        public string autoID(string tablePrimaryID)
        {
            string newID = tablePrimaryID;
            string lastID = "";
            switch (tablePrimaryID)
            {
                case "KH":
                    var kh = db.KhachHangs.Last();
                    lastID = kh.maKH;
                    break;
                case "NV":
                    var nv = db.NhanViens.Last();
                    lastID = nv.maNV;
                    break;
                default: return null;
            }
            int indexOf0 = lastID.IndexOf('0');
            string id = lastID.Substring(indexOf0);
            int index = Convert.ToInt32(id);
            index++;
            int len = 5 - tablePrimaryID.Length - index.ToString().Length;

            for (int i = 0; i < len; i++)
            {
                newID += "0";
            }
            return newID += index.ToString();
        }
        [HttpGet]
        // GET: Authenticate_62133026
        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var taikhoan = db.TaiKhoans.Find(email);
            if (taikhoan == null)
            {
                ViewBag.Mess = "Email không tồn tại!";
                return View();
            }
            else if (taikhoan.nhanVien)
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
                    var kh = db.KhachHangs.Where(khachHang => khachHang.email == email).First();
                    Session["user"] = kh.tenKH;
                    Session["maGH"] = kh.maGH;
                    return RedirectToAction("Index", "Home");
                }
            }

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "email,matKhau")] TaiKhoan taiKhoan, [Bind(Include = "email,name")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                var exitsEmail = db.TaiKhoans.Find(taiKhoan.email);

                if (exitsEmail != null)
                {
                    ViewBag.Mess = "Tài khoản đã tồn tại";
                    return View();
                }
                string id = autoID("KH");
                if(id != null)
                {
                    string tmp = id.Substring(id.IndexOf('0'));
                    int index = Convert.ToInt32(id);

                    //Tạo khách hàng mới
                    KhachHang kh = new KhachHang();
                    kh.maKH = id;
                    kh.email = taiKhoan.email;
                    kh.tenKH = "Khách hàng " + index.ToString();

                    //Tài khoản dành cho khách hàng
                    taiKhoan.nhanVien = false;
                    
                    db.KhachHangs.Add(kh);
                    db.TaiKhoans.Add(taiKhoan);
                    db.SaveChanges();

                    ViewBag.Mess = "Tạo tài khoản thành công";
                    return RedirectToAction("Index");
                }
                return View();



            }
            return View(taiKhoan);
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            

            return RedirectToAction("Index", "Home");
        }

    }
}