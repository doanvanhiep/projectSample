using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btnhom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThanhVien()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult DeTai()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}