using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_62133026.Models;

namespace Project_62133026.Controllers
{
    public class CTGHs_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: CTGHs_62133026
        public ActionResult Index()
        {
            var maCTGH = Session["maCTGH"] as string;
            var cTGHs = db.CTGHs.Include(c => c.GioHang).Include(c => c.SanPham).Where(c => c.GioHang.maGH == maGH);

            if (maCTGH == null)
            {
                // Redirect về trang đăng nhập h oặc trang chính
                return RedirectToAction("Login", "..Authentication_62133026/Login");
            }

            if (cTGHs == null)
            {
                return HttpNotFound();
            }

            if(maCTGH != null)
            {
                // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
            }
            return View(cTGHs);
        }

        public ActionResult PlusItem(string maSP)
        {
            var maCTGH = Session["maCTGH"] as List<Dictionary<string, object>>;

            if (maCTGH != null)
            {
                var item = maCTGH.FirstOrDefault(p => p["maSP"].ToString() == maSP);

                if (item != null)
                {
                    // Sửa thông tin của sản phẩm
                    item["soLuong"] = Convert.ToInt32(item["soLuong"]) + 1;
                    int soLuongItem = Convert.ToInt32(item["soLuong"]);
                    int gia = Convert.ToInt32(item["donGia"]);
                    item["thanhTien"] = soLuongItem * gia;
                    // Cập nhật lại session
                    Session["maCTGH"] = maCTGH;
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult MinusItem(string maSP)
        {
            var maCTGH = Session["maCTGH"] as List<Dictionary<string, object>>;
            if (maCTGH != null)
            {
                var item = maCTGH.FirstOrDefault(p => p["maSP"].ToString() == maSP);
                if (item != null)
                {
                    // Sửa thông tin của sản phẩm
                    var soLuong = Convert.ToInt32(item["soLuong"]);
                    if (soLuong > 1)
                    {
                        item["soLuong"] = Convert.ToInt32(item["soLuong"]) - 1;
                        int soLuongItem = Convert.ToInt32(item["soLuong"]);
                        int gia = Convert.ToInt32(item["donGia"]);
                        item["thanhTien"] = soLuongItem * gia;
                        // Cập nhật lại session
                        Session["maCTGH"] = maCTGH;
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveItem(string maSP)
        {
            var maCTGH = Session["maCTGH"] as List<Dictionary<string, object>>;

            if (maCTGH != null)
            {
                maCTGH.RemoveAll(item => item["maSP"].ToString() == maSP);
                Session["maCTGH"] = maCTGH;
            }
            return RedirectToAction("Index");
        }

        // GET: CTGHs_62133026/Details/5
        public ActionResult Details()
        {
            var maCTGH = Session["maCTGH"] as string;
            var cTGHs = db.CTGHs.Include(c => c.GioHang).Include(c => c.SanPham).Where(c => c.GioHang.maGH == maCTGH);

            if (maCTGH == null)
            {
                // Redirect về trang đăng nhập hoặc trang chính
                return RedirectToAction("Login", "./Login");
            }

            if (cTGHs == null)
            {
                return HttpNotFound();
            }

            return View(cTGHs);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
