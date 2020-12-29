using btnhom.Models;
using btnhom.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btnhom.Controllers
{
    public class HomeController : Controller
    {
        private string stateScreen = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThanhVien()
        {
            return View();
        }

        public ActionResult DeTai()
        {
            List<DataStatistic> list = new DAOData().GetAllData() ;
            return View(list);
        }

        public ActionResult UpdateData(string state)
        {
            stateScreen = state;
            return null;
        }
    }
}