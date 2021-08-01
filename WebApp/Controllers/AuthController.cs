using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.ModelDb;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        KhachHangDao user_DAO = new KhachHangDao();
        // GET: Signin
        public ActionResult Signin()
        {
            ViewBag.StrError = "";
            return View();
        }
        [HttpPost]
        public ActionResult Signin(FormCollection filed)
        {
            var error = "";
            String user = filed["phone"];
            String pass = filed["password"];
            KhachHang  user_row = user_DAO.getRow(user);
            if (user_row != null )
            {
                if (user_row.MatKhau.Equals(pass))
                {
                    Session["UserAdmin"] = user_row.TenKH;
                    Session["UserAdminId"] = user_row.MaKH;
                    return RedirectToAction("Index", "HomeUs");
                }
                else
                {
                    error = "Mật khẩu không chính xác";
                }
            }
            else
            {
                error = "Tài khoản không tồn tại";
            }

            ViewBag.StrError = "<div class='alert alert-danger'>" + error + "</div>";
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserAdmin"] = null;
            Session["UserAdminId"] = null;
            return RedirectToAction("Index", "HomeUs");
        }
    }
}