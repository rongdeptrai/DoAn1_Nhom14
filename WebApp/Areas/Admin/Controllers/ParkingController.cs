using ModelEF.DAO;
using ModelEF.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class ParkingController : BaseController
    {
        MyParkingContext db = new MyParkingContext();
        // GET: Admin/Parking
        public ActionResult Index()
        {
            ViewBag.ListODo = db.ODoes.ToList();
            ViewBag.ListLoaiODo = db.LoaiODoes.ToList();
            ViewBag.ListDatCho = db.DatChoes.OrderByDescending(x=>x.IdDatCho).ToList();
            ViewBag.ListKhachHang = db.KhachHangs.ToList();
            ViewBag.ListChiTietXe = db.ChiTietXes.ToList();
            return View();
        }
       

        [HttpPost]
        public ActionResult Create(DatCho model)
        {
            DatCho a = new DatCho();
            if (ModelState.IsValid)
            {
                ParkingDao dao = new ParkingDao();
                var d = db.KhachHangs.SingleOrDefault(x => x.MaKH.Contains(model.MaKH));

                if (d.MaLKH.Equals("MLKH01") && model.ThoiGianRaDuKien == null && model.HanCuoiHetPhi != null)
                {
                    d.MaLKH = "MLKH02";
                    db.SaveChanges();
                }
                else if (d.MaLKH.Equals("MLKH01") && model.ThoiGianRaDuKien != null && model.HanCuoiHetPhi != null|| model.HanCuoiHetPhi==null)
                {
                    d.MaLKH = "MLKH01";
                    db.SaveChanges();
                }
                else if (d.MaLKH.Equals("MLKH02") && model.ThoiGianRaDuKien != null && model.HanCuoiHetPhi == null)
                {
                    d.MaLKH = "MLKH01";
                    db.SaveChanges();
                }
                else if (d.MaLKH.Equals("MLKH02") && model.ThoiGianRaDuKien != null && model.HanCuoiHetPhi != null|| model.ThoiGianRaDuKien == null)
                {
                    d.MaLKH = "MLKH02";
                    db.SaveChanges();
                }

                model.MaDatCho = "MDC001";
                a.ThoiGianVao = model.ThoiGianVao;
                a.ThoiGianRaDuKien = model.ThoiGianRaDuKien;
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Cho thuê thành công", "success");
                    return RedirectToAction("Index", "Parking");
                }
                else
                {
                    SetAlert("Không thành công", "error");
                }

            }
            else
            {
                SetViewBag();
            }

            return View();
        }
        public void SetViewBag(string selectedid = null)
        {
            var dao = new CustomerDao();
            ViewBag.MaKH = new SelectList(dao.ListAll(), "MaKH", "MaKH", selectedid);
            var d = new ParkingDao();
            ViewBag.MaODo = new SelectList(d.Search(), "MaODo", "ViTriODo");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var rs = new ParkingDao().ChangeStatus(id);
            if (rs == true)
            {
                SetAlert("Xác nhận vào bãi thành công", "success");


            }
            return Json(new { status = rs });
        }
        [HttpPost]
        public JsonResult ChangeStatusODo(int id)
        {
            var rs = new ParkingDao().ChangeStatusODo(id);
   
            return Json(new { status = rs });
        }
        //[HttpGet]
        //public void InsertHoaDon(string maDatcho)
        //{
        //    var dao = new ParkingDao();
        //    var d = db.DatChoes.SingleOrDefault(x => x.MaDatCho.Contains(maDatcho));
        //    var dao1 = new InvoiceDao();
        //    HoaDon hd = new HoaDon();
        //    hd.MaHD = "MHD001";
        //    hd.MaDatCho = d.MaDatCho;
        //    hd.MaNV = d.MaNV;
        //    hd.TenKH = d.KhachHang.TenKH;
        //    hd.NgayLap = DateTime.Now;
        //    hd.ThoiGianRa = DateTime.Now;
        //    string result = dao1.Insert(hd);
        //    if (!string.IsNullOrEmpty(result))
        //    {
        //        SetAlert("Cho thuê thành công", "success");
        //        return RedirectToAction("Index", "Parking");
        //    }
        //    else
        //    {
        //        SetAlert("Không thành công", "error");
        //    }


        //}
       
    }
}