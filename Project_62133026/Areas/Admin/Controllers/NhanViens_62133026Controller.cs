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
    public class NhanViens_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: Admin/NhanViens_62133026
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.LoaiNhanVien).Include(n => n.TaiKhoan).Include(n => n.TaiKhoan1);
            return View(nhanViens.ToList());
        }

        // GET: Admin/NhanViens_62133026/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        public string autoID()
        {
            string id = "";
            var maNV = db.NhanViens.Count();
            maNV++;
            if (maNV > 10)
            {
                id = "NV0";
            }
            else if (maNV > 100)
            {
                id = "NV";
            }
            else
            {
                id = "NV00";
            }

            return id + maNV.ToString();
        }

        // GET: Admin/NhanViens_62133026/Create
        public ActionResult Create()
        {
            ViewBag.maLNV = new SelectList(db.LoaiNhanViens, "maLNV", "tenLNV");
            return View();
        }

        // POST: Admin/NhanViens_62133026/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNV,tenNV,sdt,email,maLNV,gioiTinh,ngaySinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.email = nhanVien.email;
                taiKhoan.matKhau = "1";
                taiKhoan.nhanVien = true;
                db.TaiKhoans.Add(taiKhoan);

                nhanVien.maNV = autoID();
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLNV = new SelectList(db.LoaiNhanViens, "maLNV", "tenLNV", nhanVien.maLNV);
            return View(nhanVien);
        }

        // GET: Admin/NhanViens_62133026/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLNV = new SelectList(db.LoaiNhanViens, "maLNV", "tenLNV", nhanVien.maLNV);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", nhanVien.email);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", nhanVien.email);
            return View(nhanVien);
        }

        // POST: Admin/NhanViens_62133026/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNV,tenNV,sdt,email,maLNV,gioiTinh,ngaySinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLNV = new SelectList(db.LoaiNhanViens, "maLNV", "tenLNV", nhanVien.maLNV);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", nhanVien.email);
            ViewBag.email = new SelectList(db.TaiKhoans, "email", "matKhau", nhanVien.email);
            return View(nhanVien);
        }

        // GET: Admin/NhanViens_62133026/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens_62133026/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
