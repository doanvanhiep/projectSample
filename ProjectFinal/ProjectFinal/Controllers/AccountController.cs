using ProjectFinal.ConnectToDB;
using ProjectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinal.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Admin"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAdmin u)
        {
            if (ModelState.IsValid)
            {
                LoginDao loginDao = new LoginDao();
                bool checkAdmin = loginDao.Login(u);
                if (checkAdmin)
                {
                    Session["Admin"] = u.TenDangNhap;
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }    
            return View(u);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterAdmin u)
        {
            if (ModelState.IsValid)
            {
                if(u.MatKhau.Equals(u.ReMatKhau))
                {
                    LoginDao loginDao = new LoginDao();
                    bool checkAdmin = loginDao.Register(u);
                    if (checkAdmin)
                    {
                        return RedirectToAction("Login");
                    }
                }   
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không khớp");
                }    

                
            }
            return View(u);
        }
    }
}