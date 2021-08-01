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
    public class HomeUsController : Controller
    {
        private Model2 db = new Model2();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ListODo = db.ODoes.ToList();
            ViewBag.ListLoaiODo = db.LoaiODoes.ToList();
            ViewBag.ListDatCho = db.DatChoes.OrderByDescending(x => x.IdDatCho).ToList();
            ViewBag.ListKhachHang = db.KhachHangs.ToList();
            ViewBag.ListChiTietXe = db.ChiTietXes.ToList();
            return PartialView();

        }
    }
}