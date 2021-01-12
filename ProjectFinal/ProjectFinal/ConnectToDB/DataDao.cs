using ProjectFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectFinal.ConnectToDB
{
    public class DataDao
    {
        // Property error to show error for user
        private string errorMessage;

        // Property error to show error for user
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
        public List<DataStatistic> GetAllData()
        {
            try
            {
                //Inital class connecto to DB
                ConnectToDB connectToDB = new ConnectToDB();

                //Query string to query data
                string queryString = "select top 200 * from bang1 order by THOI_GIAN desc";
                //Declare dataset, excute query and assign result to dataset
                DataSet dsResult = connectToDB.ExecuteQueryDataSet(queryString, System.Data.CommandType.Text, ref errorMessage);

                //Declare list DataStatistic to contain result 
                List<DataStatistic> listDatas = new List<DataStatistic>();

                //Check dataset result difference null and number of row in table's datataset larger than 0
                if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                {
                    //Loop result in table result to assign data 
                    foreach (DataRow data in dsResult.Tables[0].Rows)
                    {
                        DataStatistic newData = new DataStatistic(data["ID"].ToString(),
                            data["TEN_CB"].ToString(), Convert.ToDouble(data["GIA_TRI_CB"].ToString()),
                            ((DateTime)data["THOI_GIAN"]).ToString("dd/MM/yyyy hh:mm:ss tt"));

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
        public List<DataStatistic> GetAllDataOnline()
        {
            try
            {
                //Inital class connecto to DB
                ConnectToDB connectToDB = new ConnectToDB();
                List<string> listCamBien = new List<string>
                {
                    "A001",
                    "A002",
                    "A003",
                    "B001",
                    "B002",
                    "B003",
                };

                //Query string to query data
                //string queryString = "select Top 1 * from bang1 where ID='{0}' order by THOI_GIAN desc";
                string queryString = "select Top 1 * from bang1 where TEN_CB='{0}' order by THOI_GIAN desc";

                //Declare dataset, excute query and assign result to dataset


                //Declare list DataStatistic to contain result 
                List<DataStatistic> listDatas = new List<DataStatistic>();

                foreach (var cb in listCamBien)
                {
                    DataSet dsResultTemp = connectToDB.ExecuteQueryDataSet(string.Format(queryString, cb), System.Data.CommandType.Text, ref errorMessage);
                    if (dsResultTemp != null && dsResultTemp.Tables[0].Rows.Count > 0)
                    {
                        //Loop result in table result to assign data 
                        foreach (DataRow data in dsResultTemp.Tables[0].Rows)
                        {
                            DataStatistic newData = new DataStatistic(data["ID"].ToString(),
                                data["TEN_CB"].ToString(), Convert.ToDouble(data["GIA_TRI_CB"].ToString()),
                                ((DateTime)data["THOI_GIAN"]).ToString("dd/MM/yyyy hh:mm:ss tt"));

                            //Add object lineitem to list result
                            listDatas.Add(newData);
                        }
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