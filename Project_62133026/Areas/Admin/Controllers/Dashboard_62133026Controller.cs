using Project_62133026.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_62133026.Areas.Admin.Controllers
{
    public class Dashboard_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();
        // GET: Admin/Dashboard_62133026
        public ActionResult Index()
        {
            //đếm số lượng khách hàng
            int countKH = db.KhachHangs.Count();
            //đếm số lượng hóa đơn
            int countHD = db.HoaDons.Count();
            //tổng doanh thu
            
            ViewBag.countKH = countKH;
            ViewBag.countHD = countHD;

            return View();
        }
    }
}