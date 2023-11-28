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
    public class KhachHangs_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: Admin/KhachHangs_62133026
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.TaiKhoan).Include(k => k.TaiKhoan1);
            return View(khachHangs.ToList());
        }

        // GET: Admin/KhachHangs_62133026/Details/5
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

        public string autoID()
        {
            string id = "";
            var khachHang = db.KhachHangs.Last();
            string lastNumber = khachHang.maKH.Substring(2);
            int index = Convert.ToInt32(lastNumber);
            index++;

            if (index > 9) { id = "KH0"; }
            else if (index > 99) { id = "KH"; }
            else { id = "KH00"; }

            // Get last name

            return id + khachHang.ToString();
        }

        // GET: Admin/KhachHangs_62133026/Create
        public ActionResult Create()
        {
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau");
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau");
            return View();
        }

        // POST: Admin/KhachHangs_62133026/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maKH,tenKH,sdt,email,diaChi")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                khachHang.maKH = autoID();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            return View(khachHang);
        }

        // GET: Admin/KhachHangs_62133026/Edit/5
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
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            return View(khachHang);
        }

        // POST: Admin/KhachHangs_62133026/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maKH,tenKH,sdt,email,diaChi")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", khachHang.email);
            return View(khachHang);
        }

        // GET: Admin/KhachHangs_62133026/Delete/5
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

        // POST: Admin/KhachHangs_62133026/Delete/5
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
