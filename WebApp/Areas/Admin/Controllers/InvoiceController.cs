using ModelEF.DAO;
using ModelEF.ModelDb;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class InvoiceController : BaseController
    {
        MyParkingContext db = new MyParkingContext();
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var cus = new InvoiceDao();
            var model = cus.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        // GET: Admin/User
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var cus = new InvoiceDao();
            var model = cus.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create(string maDatCho)
        {
            var dao = new ParkingDao();
            var d = db.DatChoes.SingleOrDefault(x => x.MaDatCho.Contains(maDatCho));
            var dao1 = new InvoiceDao();
            HoaDon hd = new HoaDon();
            hd.MaHD = "MHD001";
            hd.MaDatCho = maDatCho;
            hd.MaNV = d.MaNV;
            hd.TenKH = d.KhachHang.TenKH;
            hd.NgayLap = DateTime.Now;
            hd.ThoiGianRa = DateTime.Now;
            string result = dao1.Insert(hd);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Thanh toán thành công", "success");
                return RedirectToAction("Index", "Invoice");
            }
            else
            {
                SetAlert("Không thành công", "error");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Detail(string maHD)
        {

            var dao = new InvoiceDao();
            var result = dao.Find(maHD);
            if (result != null)
                return View(result);
            return View();
        }
    }
}