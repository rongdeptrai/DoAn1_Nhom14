using ModelEF.ModelDb;
using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApp.Controllers
{

    public class DatChosController : Controller
    {
        Model2 db = new Model2();

        [HttpPost]
        public ActionResult Create(FormCollection filed)
        {
            DatCho dc = new DatCho();
            dc.MaDatCho = "MDC001";
            DateTime ThoiGianVao = DateTime.Now;
            dc.ThoiGianVao = ThoiGianVao;
            String sdt = filed["SoDienThoai"];
            dc.SoDienThoai = sdt;
            String TenKH = filed["TenKH"];
            dc.TenKH = TenKH;
            String MaKH = filed["MaKH"];
            dc.MaKH = MaKH;
            String bsx = filed["BienSoXe"];
            dc.BienSoXe = bsx;
            String MaODo = filed["MaODo"];
            dc.MaODo = MaODo;
            DateTime ThoiGianRaDuKien = DateTime.Parse(filed["ThoiGianRaDuKien"]);
            dc.ThoiGianRaDuKien = ThoiGianRaDuKien;
            int day = (ThoiGianRaDuKien - ThoiGianVao).Days;
            if (ModelState.IsValid)
            {
                KhachHang kh = db.KhachHangs.Find(MaKH);
                if (day >= 30)
                {
                    if (kh.MaLKH.Equals("MLKH01"))
                    {
                        kh.MaLKH = "MLKH02";
                        db.Entry(kh).State = EntityState.Modified;
                        db.SaveChanges();
                        dc.NgayBatDauApDung = ThoiGianVao;
                        dc.HanCuoiHetPhi = ThoiGianRaDuKien;
                    }
                    else
                    {
                        dc.NgayBatDauApDung = ThoiGianVao;
                        dc.HanCuoiHetPhi = ThoiGianRaDuKien;
                    }
                }
                else
                {
                    if (kh.MaLKH.Equals("MLKH02"))
                    {
                        kh.MaLKH = "MLKH01";
                        db.Entry(kh).State = EntityState.Modified;
                        db.SaveChanges();
                        dc.NgayBatDauApDung = ThoiGianVao;
                        dc.HanCuoiHetPhi = ThoiGianRaDuKien;
                    }
                }
                db.DatChoes.Add(dc);
                db.SaveChanges();
                return RedirectToAction("Index", "HomeUs", new { dc });
            }

            return RedirectToAction("Index", "HomeUs", new { dc });
        }
    }
}