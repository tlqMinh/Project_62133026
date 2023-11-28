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
    public class CTGHs_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: Admin/CTGHs_62133026
        public ActionResult Index()
        {
            var cTGHs = db.CTGHs.Include(c => c.GioHang).Include(c => c.SanPham);
            return View(cTGHs.ToList());
        }

        // GET: Admin/CTGHs_62133026/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTGH cTGH = db.CTGHs.Find(id);
            if (cTGH == null)
            {
                return HttpNotFound();
            }
            return View(cTGH);
        }

        // GET: Admin/CTGHs_62133026/Create
        public ActionResult Create()
        {
            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maKH");
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maLSP");
            return View();
        }

        // POST: Admin/CTGHs_62133026/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maGH,maSP,soLuong,daThanhToan")] CTGH cTGH)
        {
            if (ModelState.IsValid)
            {
                db.CTGHs.Add(cTGH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maKH", cTGH.maGH);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maLSP", cTGH.maSP);
            return View(cTGH);
        }

        // GET: Admin/CTGHs_62133026/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTGH cTGH = db.CTGHs.Find(id);
            if (cTGH == null)
            {
                return HttpNotFound();
            }
            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maKH", cTGH.maGH);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maLSP", cTGH.maSP);
            return View(cTGH);
        }

        // POST: Admin/CTGHs_62133026/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maGH,maSP,soLuong,daThanhToan")] CTGH cTGH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTGH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maGH = new SelectList(db.GioHangs, "maGH", "maKH", cTGH.maGH);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maLSP", cTGH.maSP);
            return View(cTGH);
        }

        // GET: Admin/CTGHs_62133026/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTGH cTGH = db.CTGHs.Find(id);
            if (cTGH == null)
            {
                return HttpNotFound();
            }
            return View(cTGH);
        }

        // POST: Admin/CTGHs_62133026/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTGH cTGH = db.CTGHs.Find(id);
            db.CTGHs.Remove(cTGH);
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
