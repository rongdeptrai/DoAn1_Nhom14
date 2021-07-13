using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Admin.Model;
using WebApp.Common;

namespace WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                int result = dao.login(user.UserName, Encryptor.EncryptMD5(user.PassWord));
                if (result == 1)
                {
                    //ModelState.AddModelError("","Đăng Nhập Thành Công");
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Thành Công");
                }
            }
            return View("Index");
        }

    }
}