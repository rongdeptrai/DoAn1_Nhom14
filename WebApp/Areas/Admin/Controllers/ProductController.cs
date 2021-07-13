using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        LeHoangLongContext db = new LeHoangLongContext();

        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        // GET: Admin/Product
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }


        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase imgfile)
        {
            var dao = new ProductDao();
            imgfile = Request.Files["ImageData"];
            string path = uploadimage(imgfile);
            try
            {
                if (path.Equals("-1"))
                {
                    SetAlert("Chọn ảnh", "error");
                    return RedirectToAction("Create", "Product");
                }
                else
                {
                    product.ProductImg = path;
                    dao.Insert(product);
                    SetAlert("Tạo sản phẩm thành công.", "success");
                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception ex)
            {
                SetAlert("Tạo sản phẩm không thành công.", "success");
            }
            return View();
        }

        public string uploadimage(HttpPostedFileBase imgfile)
        {

            string path = "-1";
            if (imgfile != null && imgfile.ContentLength > 0)
            {
                string extension = Path.GetExtension(imgfile.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Assets/Upload/") + Path.GetFileName(imgfile.FileName));
                        imgfile.SaveAs(path);
                        path = "~/Assets/Upload/" + Path.GetFileName(imgfile.FileName);
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Chi up anh co dinh dạng jpg,jpeg và png');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Chon ảnh');</script>");
                path = "-1";
            }
            return path;
        }

        [HttpGet]
        public ActionResult Update(int productID)
        {
            SetViewBag();
            var dao = new ProductDao();
            var result = dao.Find(productID);
            if (result != null)
                return View(result);
            return View();
        }
        [Route("Update")]
        [HttpPost]
        public ActionResult Update(Product model, HttpPostedFileBase imgfile)
        {
            imgfile = Request.Files["ImageData"];
            string path = uploadimage(imgfile);

            var dao = new ProductDao();
            if (!string.IsNullOrEmpty(path))
            {

                model.ProductImg = path;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Cập nhật sản phẩm thành công.", "success");
                return RedirectToAction("Index", "Product");
            }
            else
            {
                SetAlert("Chọn ảnh", "error");
                return RedirectToAction("Create", "Product");

            }
        }
        [HttpDelete]
        public ActionResult Delete(int productid)
        {
            var d = productid;
            ProductDao dao = new ProductDao();
            var result = new ProductDao().Delete(productid);
            result = dao.Delete(productid);

            if (result)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index");

        }
        public void SetViewBag(string selectedid = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "CategoryID", "CategoryName", selectedid);
        }
        [HttpGet]
        public ActionResult Detail(int productID)
        {
           
            var dao = new ProductDao();
            var result = dao.Find(productID);
            if (result != null)
                return View(result);
            return View();
        }


    }
}