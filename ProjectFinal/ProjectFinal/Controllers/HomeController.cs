using ProjectFinal.ConnectToDB;
using ProjectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFinal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MoPhong()
        {
            return View();
        }

        public ActionResult GiamSatOnLine()
        {
            //GetData when the first load
            List<DataStatistic> dataOnline = new DataDao().GetAllDataOnline();
            //Return view for user
            return View(dataOnline);
        }

        public JsonResult GetAllDataOnline()
        {
            //Load data after 2 minutes
            List<DataStatistic> list = new DataDao().GetAllDataOnline();

            //Retrun json cause call AJAX only receive format json
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DuLieu()
        {
            //GetData when the first load
            List<DataStatistic> dataOnline =  new DataDao().GetAllData();
            //Return view for user
            return View(dataOnline);
        }

        public ActionResult LichSuHoatDong()
        {
            //GetData when the first load
            List<LichSuHoatDong> dataHistory = new LichSuHoatDongDao().GetAllDataLichSuHoatDong();
            //Return view for user
            return View(dataHistory);
        }
        public ActionResult ThanhPhanHeThong()
        {
            //Return view for user
            return View();
        }

        public ActionResult HuongDan()
        {
            //Return view for user
            return View();
        }

        public JsonResult GetAllData()
        {
            //Load data after 2 minutes
            List<DataStatistic> list = new DataDao().GetAllData();

            //Retrun json cause call AJAX only receive format json
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllDataLichSuHoatDongByTime(string startDate, string endDate)
        {
            //GetData when the first load
            List<LichSuHoatDong> dataHistory = new LichSuHoatDongDao().GetAllDataLichSuHoatDongByTime(startDate, endDate);
            //Return view for user
            return Json(dataHistory, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllDataByTime(string startDate, string endDate)
        {
            //Load data after 2 minutes
            List<DataStatistic> list = new DataDao().GetAllDataByTime(startDate, endDate);

            //Retrun json cause call AJAX only receive format json
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}