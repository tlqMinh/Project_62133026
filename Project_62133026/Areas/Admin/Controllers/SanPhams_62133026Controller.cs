using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_62133026.Models;

namespace Project_62133026.Areas.Admin
{
    public class SanPhams_62133026Controller : Controller
    {
        private QLBDGT_62133026Entities db = new QLBDGT_62133026Entities();

        // GET: Admin/SanPhams_62133026
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(sanPhams.ToList());
        }

        // GET: Admin/SanPhams_62133026/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        public string autoID()
        {
            string id = "";
            var sanPham = db.SanPhams.Count();
            sanPham++;
            if (sanPham > 10)
            {
                id = "SP0";
            }
            else if (sanPham > 100)
            {
                id = "SP";
            }
            else
            {
                id = "SP00";
            }

            return id + sanPham.ToString();
        }

        // GET: Admin/SanPhams_62133026/Create
        public ActionResult Create()
        {

            ViewBag.maLSP = new SelectList(db.LoaiSanPhams, "maLSP", "tenLSP");
            return View();
        }

        // POST: Admin/SanPhams_62133026/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSP,maLSP,tenSP,moTa,donViTinh,donGia,anh")] SanPham sanPham)
        {
            var imgSP = Request.Files["Avatar"];
            string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
            var path = Server.MapPath("/Image/" + postedFileName);
            imgSP.SaveAs(path);

            if (ModelState.IsValid)
            {
                sanPham.anh = postedFileName;
                sanPham.maSP = autoID();
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLSP = new SelectList(db.LoaiSanPhams, "maLSP", "tenLSP", sanPham.maLSP);
            return View(sanPham);
        }


        // GET: Admin/SanPhams_62133026/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLSP = new SelectList(db.LoaiSanPhams, "maLSP", "tenLSP", sanPham.maLSP);
            return View(sanPham);
        }

        // POST: Admin/SanPhams_62133026/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSP,maLSP,tenSP,moTa,donViTinh,donGia,anh")] SanPham sanPham)
        {
            var imgSP = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Image/" + postedFileName);
                imgSP.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLSP = new SelectList(db.LoaiSanPhams, "maLSP", "tenLSP", sanPham.maLSP);
            return View(sanPham);
        }

        // GET: Admin/SanPhams_62133026/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams_62133026/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
