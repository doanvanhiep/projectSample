using btnhom.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace btnhom.SQL
{
    public class DAOData
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
                ConnectDB connectToDB = new ConnectDB();

                //Query string to query data
                string queryString = "Select * from table1";
                //Declare dataset, excute query and assign result to dataset
                DataSet dsResult = connectToDB.ExecuteQueryDataSet(queryString, System.Data.CommandType.Text,ref errorMessage);

                //Declare list lineitem to contain result 
                List<DataStatistic> listDatas = new List<DataStatistic>();

                for (int item = 500; item>0; item--)
                {
                    //Declare object lineitem 
                    DataStatistic newData = new DataStatistic(item.ToString()+"A", item.ToString() + "B", item.ToString() + "C", item.ToString() + "D");

                    //Add object lineitem to list result
                    listDatas.Add(newData);
                }

                //Check dataset result difference null and number of row in table's datataset larger than 0
                //if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                //{
                //    //Loop result in table result to assign data 
                //    foreach (DataRow data in dsResult.Tables[0].Rows)
                //    {
                //        //Declare object lineitem 
                //        DataStatistic newData = new DataStatistic(data["A"].ToString(), data["A"].ToString(), data["A"].ToString(), data["A"].ToString());

                //        //Add object lineitem to list result
                //        listDatas.Add(newData);
                //    }
                //}

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