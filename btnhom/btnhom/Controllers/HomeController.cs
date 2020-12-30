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
        private static int total = 10;

        public JsonResult GetAllData()
        {
            //Declare list lineitem to contain result 
            List<DataStatistic> listDatas = new List<DataStatistic>();

            for (int item = total; item >0; item--)
            {
                //Declare object lineitem 
                DataStatistic newData = new DataStatistic(item.ToString() + "A", item.ToString() + "B", item.ToString() + "C", item.ToString() + "D");

                //Add object lineitem to list result
                listDatas.Add(newData);
            }
            total += 5;
            return Json(listDatas, JsonRequestBehavior.AllowGet);
        }
    }
}