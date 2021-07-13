using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;

namespace WebApp.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var cus = new CustomerDao();
            var model = cus.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        // GET: Admin/User
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var cus = new CustomerDao();
            var model = cus.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if (dao.Find(model.UserName) != null)
                {
                    SetAlert("Tên người dùng đã tồn tại. Mời nhập tên khác.", "warning");
                    return RedirectToAction("Create", "Customer");
                }
                var pass = Encryptor.EncryptMD5(model.Password);
                model.Password = pass;
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Tạo mới khách hàng thành công.", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    SetAlert("Tạo mới khách hàng không thành công.", "error");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Update(string user)
        {
            var dao = new CustomerDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        public ActionResult Update(UserAccount model)
        {

            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var pass = Encryptor.EncryptMD5(model.Password);
                model.Password = pass;
                string result = "";
                var s = model.Status;
                result = dao.Update(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Cập nhật người dùng thành công.", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    SetAlert("Cập nhật người dùng không thành công.", "error");
                }
            }
            return View();
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string username)
        {
            var dao = new CustomerDao().Delete(username);
            return RedirectToAction("Index");

        }
        [HttpPost]
         public JsonResult ChangeStatus(int id )
        {
            var rs = new CustomerDao().ChangeStatus(id);
            
            return Json(new { status = rs });
        }
    }
}