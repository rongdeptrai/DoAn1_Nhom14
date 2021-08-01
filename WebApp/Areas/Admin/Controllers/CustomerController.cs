using ModelEF.DAO;
using ModelEF.ModelDb;
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
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if (dao.Search(model.Email,model.SoDienThoai) >0)
                {
                    SetAlert("Email hoặc Số điện thoại đã tồn tại. Mời nhập lại.", "warning");
                    return RedirectToAction("Create", "Customer");
                }
                else
                {
                    var pass = Encryptor.EncryptMD5(model.MatKhau);
                    model.MaKH = "1";
                    model.MatKhau = pass;
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
            }
            else
            {
                SetViewBag();
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
        public ActionResult Update(KhachHang model)
        {

            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var pass = Encryptor.EncryptMD5(model.MatKhau);
                model.MatKhau = pass;
                string result = "";
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

        public ActionResult Delete(string username)
        {
            var dao = new CustomerDao().Delete(username);
            return RedirectToAction("Index");

        }
        public void SetViewBag(string selectedid = null)
        {
            var dao = new CustomerTypeDao();
            ViewBag.MaLKH = new SelectList(dao.ListAll(), "MaLKH", "TenLKH", selectedid);
        }

    }
}