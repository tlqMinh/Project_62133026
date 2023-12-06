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
    public class KhachHangs_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: KhachHangs_62133026
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.GioHang).Include(k => k.TaiKhoan);
            return View(khachHangs.ToList());
        }

        // GET: KhachHangs_62133026/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangs_62133026/Create
        public ActionResult Create()
        {
            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maGH");
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau");
            return View();
        }

        // POST: KhachHangs_62133026/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maKH,hoKH,tenKH,sdt,email,diaChi,maGH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maGH", khachHang.maGH);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            return View(khachHang);
        }

        // GET: KhachHangs_62133026/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maGH", khachHang.maGH);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            return View(khachHang);
        }

        // POST: KhachHangs_62133026/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maKH,hoKH,tenKH,sdt,email,diaChi,maGH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maGH", khachHang.maGH);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            return View(khachHang);
        }

        // GET: KhachHangs_62133026/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs_62133026/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
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
