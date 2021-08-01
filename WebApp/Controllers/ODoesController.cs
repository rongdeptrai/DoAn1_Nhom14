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
    public class ODoesController : Controller
    {
        private Model2 db = new Model2();

        // GET: ODoes
        public ActionResult Index()
        {
            var oDoes = db.ODoes.Include(o => o.LoaiODo);
            return View(oDoes.ToList());
        }

        // GET: ODoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODo oDo = db.ODoes.Find(id);
            if (oDo == null)
            {
                return HttpNotFound();
            }
            return View(oDo);
        }

        // GET: ODoes/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiO = new SelectList(db.LoaiODoes, "MaLoaiO", "TenloaiO");
            return View();
        }

        // POST: ODoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaODo,IdODo,ViTriODo,TrangThai,Tang,MaLoaiO")] ODo oDo)
        {
            if (ModelState.IsValid)
            {
                db.ODoes.Add(oDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiO = new SelectList(db.LoaiODoes, "MaLoaiO", "TenloaiO", oDo.MaLoaiO);
            return View(oDo);
        }

        // GET: ODoes/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            ODo oDo = db.ODoes.Find(id);
            if (ModelState.IsValid)
            {
                oDo.TrangThai = "2";
                db.Entry(oDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "HomeUs");
            }
          return RedirectToAction("Index", "HomeUs");
        }
    }

}
