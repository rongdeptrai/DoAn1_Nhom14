using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.ModelDb;

namespace WebApp.Controllers
{
    public class KhachHangsController : Controller
    {
        private Model2 db = new Model2();

        // GET: KhachHangs
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.LoaiKhachHang);
            return View(khachHangs.ToList());
        }

        // GET: KhachHangs/Details/5
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
            ViewBag.ListChiTietXe = db.ChiTietXes.Where(x => x.MaKH == id).ToList();
            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaLKH = new SelectList(db.LoaiKhachHangs, "MaLKH", "TenLKH");
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,IdKH,TenKH,DiaChi,Email,SoDienThoai,GioiTinh,MatKhau,MaLKH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLKH = new SelectList(db.LoaiKhachHangs, "MaLKH", "TenLKH", khachHang.MaLKH);
            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
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
            ViewBag.MaLKH = new SelectList(db.LoaiKhachHangs, "MaLKH", "TenLKH", khachHang.MaLKH);
            ViewBag.ListChiTietXe = db.ChiTietXes.Where(x => x.MaKH == id).ToList();
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,IdKH,TenKH,DiaChi,Email,SoDienThoai,GioiTinh,MatKhau,MaLKH,HinhAnh")] KhachHang khachHang, HttpPostedFileBase image)
        {

            if (image != null && image.ContentLength > 0)
            {
                int sizeUpload = image.ContentLength;
                if (sizeUpload > (4000 * 1024))
                {
                    ViewBag.StrError = "<div class='text-red-500 my-2 ml-4'>Vui lòng chọn ảnh nhỏ hơn 4 Mb</div>";
                    ViewBag.MaLKH = new SelectList(db.LoaiKhachHangs, "MaLKH", "TenLKH", khachHang.MaLKH);
                    return View();
                }
                string fileName = Path.GetFileName(image.FileName);
                string urlImage = Server.MapPath("/Image/" + fileName);
                image.SaveAs(urlImage);
                khachHang.HinhAnh = "/Image/" + fileName;


            }
            else
            {
                khachHang.HinhAnh = khachHang.HinhAnh;
            }

            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","KhachHangs", new { id = khachHang.MaKH });
            }
            return RedirectToAction("Details", "KhachHangs", new { id = khachHang.MaKH });
        }

        // GET: KhachHangs/Delete/5
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

        // POST: KhachHangs/Delete/5
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
