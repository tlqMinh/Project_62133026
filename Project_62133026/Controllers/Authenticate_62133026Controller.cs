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

        public string autoID(string tableName)
        {
            string newID = tableName;
            string lastNumber = "";
            if (tableName == "KH")
            {
                var kh = db.KhachHangs.OrderByDescending(x => x.maKH).FirstOrDefault();
                if (kh == null)
                {
                    return "KH001";
                }
                string maKH = kh.maKH;
                lastNumber = maKH.Substring(maKH.IndexOf('0'));
            }
            if (tableName == "GH")
            {
                var gh = db.GioHangs.OrderByDescending(x => x.maGH).FirstOrDefault();
                if (gh == null)
                {
                    return "GH001";
                }
                string maGH = gh.maGH;
                lastNumber = maGH.Substring(maGH.IndexOf("0"));
            }

            int index = Convert.ToInt32(lastNumber);
            index++;

            int len = 5 - newID.Length - index.ToString().Length;

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
                    Session["maGH"] = kh.maGH;
                    Session["user"] = kh.tenKH;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(string firstName, string lastName, string email, string password, string confirm)
        {
            var taikhoan = db.TaiKhoans.Find(email);
            if (taikhoan != null)
            {
                ViewBag.Mess = "Email đã tồn tại!";
                return View();
            }
            else
            {
                if (password != confirm)
                {
                    ViewBag.Mess = "Mật khẩu nhập lại không khớp";

                    ViewBag.firstName = firstName;
                    ViewBag.lastName = lastName;
                    ViewBag.email = email;
                    return View();
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        //Tạo mới tài khoản
                        TaiKhoan taiKhoan = new TaiKhoan();
                        taiKhoan.email = email;
                        taiKhoan.matKhau = password;
                        taiKhoan.nhanVien = false;
                        db.TaiKhoans.Add(taiKhoan);

                        string newMaGH = autoID("GH");
                        //Tạo mới giỏ hàng
                        GioHang gioHang = new GioHang();
                        gioHang.maGH = newMaGH;
                        db.GioHangs.Add(gioHang);

                        //Tạo mới khách hàng
                        KhachHang khachHang = new KhachHang();
                        khachHang.maKH = autoID("KH");
                        khachHang.email = email;
                        khachHang.maGH = newMaGH;
                        khachHang.tenKH = firstName;
                        khachHang.hoKH = lastName;
                        db.KhachHangs.Add(khachHang);

                        db.SaveChanges();
                        return RedirectToAction("Login", "Authenticate_62133026");
                    }
                    ViewBag.firstName = firstName;
                    ViewBag.lastName = lastName;
                    ViewBag.email = email;
                    return View();
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            

            return RedirectToAction("Index", "Home");
        }

    }
}