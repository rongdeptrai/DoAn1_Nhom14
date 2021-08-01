using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Admin.Model;
using WebApp.Common;

namespace WebApp.Controllers
{
    public class SiginController : Controller
    {
        // GET: Login
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
                var dao = new CustomerDao();
                int result = dao.login(user.UserName, Encryptor.EncryptMD5(user.PassWord));
                if (result == 1)
                {
                    
                        Session.Add(Constants.USER_SESSION, user);
                        return RedirectToAction("Index", "HomeUs");
                 
                
                    
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