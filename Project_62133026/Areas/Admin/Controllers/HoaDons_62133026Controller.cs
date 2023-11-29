using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_62133026.Models;

namespace Project_62133026.Areas.Admin.Controllers
{
    public class HoaDons_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: Admin/HoaDons_62133026
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.NhanVien);
            return View(hoaDons.ToList());
        }

        // GET: Admin/HoaDons_62133026/Details/5
        

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
