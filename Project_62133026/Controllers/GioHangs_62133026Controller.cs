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
    public class GioHangs_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: GioHangs_62133026
        public ActionResult GioHang()
        {
            if (Session["user"] != null)
            {
                string gh = Session["maGH"].ToString();
                ViewBag.maGH = HttpUtility.HtmlEncode(gh);
                if (gh == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var ctgh = db.CTGHs.Where(ct => ct.maGH == gh).ToList();
                return View(ctgh);
            }
            return RedirectToAction("Login", "Authenticate_62133026");
        }
        public string autoID()
        {
            string newID = "CT";
            string lastNumber = "";

            var gh = db.CTGHs.OrderByDescending(x => x.maCTGH).FirstOrDefault();
            if (gh == null)
            {
                return "CT001";
            }
            string maCTGH = gh.maCTGH;
            lastNumber = maCTGH.Substring(maCTGH.IndexOf("0"));

            int index = Convert.ToInt32(lastNumber);
            index++;

            int len = 5 - newID.Length - index.ToString().Length;

            for (int i = 0; i < len; i++)
            {
                newID += "0";
            }
            return newID += index.ToString();
        }
        public ActionResult AddToCart(string maSP)
        {
            string maGH = Session["maGH"].ToString();
            var ghs = db.CTGHs.Where(c => c.maGH == maGH && c.maSP == maSP).FirstOrDefault();

            if(ghs == null)
            {                
                CTGH ctgh = new CTGH();

                ctgh.maGH = maGH;
                ctgh.maCTGH = autoID();
                ctgh.maSP = maSP;
                ctgh.soLuong = 1;
                ctgh.daThanhToan = false;

                db.CTGHs.Add(ctgh);
                db.SaveChanges();
                return RedirectToAction("GioHang");
            }
            else
            {
                ghs.soLuong++;
                db.SaveChanges();
                return RedirectToAction("GioHang");
            }
        }
        public ActionResult DeleteProduct(string id)
        {
            var ctgh = db.CTGHs.Find(id);
            if(ctgh.soLuong > 1)
            {
                ctgh.soLuong--;
                db.SaveChanges();
                return RedirectToAction("GioHang");
            }
            db.CTGHs.Remove(ctgh);
            db.SaveChanges();
            return RedirectToAction("GioHang");
        }
        public ActionResult Payment(string id)
        {

            return RedirectToAction("GioHang");
        }
        // GET: GioHangs_62133026/Delete/5
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
