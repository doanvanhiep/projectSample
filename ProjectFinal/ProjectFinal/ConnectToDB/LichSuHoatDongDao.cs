using ProjectFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectFinal.ConnectToDB
{
    public class LichSuHoatDongDao
    {
        // Property error to show error for user
        private string errorMessage;

        // Property error to show error for user
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
        public List<LichSuHoatDong> GetAllDataLichSuHoatDong()
        {
            try
            {
                //Inital class connecto to DB
                ConnectToDB connectToDB = new ConnectToDB();

                //Query string to query data
                string queryString = "select top 200 * from LichSuHoatDong order by Thoi_Gian desc";

                //Declare dataset, excute query and assign result to dataset
                DataSet dsResult = connectToDB.ExecuteQueryDataSet(queryString, System.Data.CommandType.Text, ref errorMessage);

                //Declare list DataStatistic to contain result 
                List<LichSuHoatDong> listDatas = new List<LichSuHoatDong>();

                //Check dataset result difference null and number of row in table's datataset larger than 0
                if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                {
                    //Loop result in table result to assign data 
                    foreach (DataRow data in dsResult.Tables[0].Rows)
                    {
                        LichSuHoatDong newData = new LichSuHoatDong(data["Ten_Thiet_Bi"].ToString(),
                            Convert.ToInt32(data["Trang_Thai"].ToString()) == 1 ? "ON" : "OFF",
                            ((DateTime)data["Thoi_Gian"]).ToString("dd/MM/yyyy hh:mm:ss tt"));

                        //Add object lineitem to list result
                        listDatas.Add(newData);
                    }
                }

                //return result
                return listDatas;
            }
            catch (Exception exception)
            {
                //Assin error and return result
                errorMessage = exception.Message;
                return null;
            }
        }
        public List<LichSuHoatDong> GetAllDataLichSuHoatDongByTime(string startDate,string endDate)
        {
            try
            {
                //Inital class connecto to DB
                ConnectToDB connectToDB = new ConnectToDB();

                //Query string to query data
                string queryString = string.Format("select top 200 * from LichSuHoatDong where " +
                    "Thoi_Gian >= '{0}' and Thoi_Gian <= '{1}' order by Thoi_Gian desc", startDate,endDate);

                //Declare dataset, excute query and assign result to dataset
                DataSet dsResult = connectToDB.ExecuteQueryDataSet(queryString, System.Data.CommandType.Text, ref errorMessage);

                //Declare list DataStatistic to contain result 
                List<LichSuHoatDong> listDatas = new List<LichSuHoatDong>();

                //Check dataset result difference null and number of row in table's datataset larger than 0
                if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                {
                    //Loop result in table result to assign data 
                    foreach (DataRow data in dsResult.Tables[0].Rows)
                    {
                        LichSuHoatDong newData = new LichSuHoatDong(data["Ten_Thiet_Bi"].ToString(),
                            Convert.ToInt32(data["Trang_Thai"].ToString()) == 1 ? "ON" : "OFF",
                            ((DateTime)data["Thoi_Gian"]).ToString("dd/MM/yyyy hh:mm:ss tt"));

                        //Add object lineitem to list result
                        listDatas.Add(newData);
                    }
                }

                //return result
                return listDatas;
            }
            catch (Exception exception)
            {
                //Assin error and return result
                errorMessage = exception.Message;
                return null;
            }
        }

    }
}