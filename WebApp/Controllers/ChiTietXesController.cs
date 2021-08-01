using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.ModelDb;

namespace WebApp.Controllers
{
    public class ChiTietXesController : Controller
    {
        private Model2 db = new Model2();

        // GET: ChiTietXes
        public ActionResult Index()
        {
            var chiTietXes = db.ChiTietXes.Include(c => c.KhachHang);
            return View(chiTietXes.ToList());
        }

        // GET: ChiTietXes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietXe chiTietXe = db.ChiTietXes.Find(id); 
            if (chiTietXe == null)
            {
                return HttpNotFound();
            }
            return View(chiTietXe);
        }

        // GET: ChiTietXes/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: ChiTietXes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTX,BienSoXe,LoaiXe,HangXe,MaKH")] ChiTietXe chiTietXe)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietXes.Add(chiTietXe);
                db.SaveChanges();
                return RedirectToAction("Details", "KhachHangs", new { id = chiTietXe.MaKH });
            }
            return RedirectToAction("Details", "KhachHangs", new { id = chiTietXe.MaKH });
        }

        // GET: ChiTietXes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietXe chiTietXe = db.ChiTietXes.Find(id);
            if (chiTietXe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", chiTietXe.MaKH);
            return View(chiTietXe);
        }

        // POST: ChiTietXes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BienSoXe,LoaiXe,HangXe,MaKH,MaCTX")] ChiTietXe chiTietXe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietXe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "KhachHangs", new { id = chiTietXe.MaKH });
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", chiTietXe.MaKH);
            return RedirectToAction("Details", "KhachHangs", new { id = chiTietXe.MaKH });
        }

        // GET: ChiTietXes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietXe chiTietXe = db.ChiTietXes.Find(id);
            if (chiTietXe == null)
            {
                return HttpNotFound();
            }
            return View(chiTietXe);
        }

        // POST: ChiTietXes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietXe chiTietXe = db.ChiTietXes.Find(id);
            db.ChiTietXes.Remove(chiTietXe);
            db.SaveChanges();
            return RedirectToAction("Details", "KhachHangs", new { id = chiTietXe.MaKH });
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
