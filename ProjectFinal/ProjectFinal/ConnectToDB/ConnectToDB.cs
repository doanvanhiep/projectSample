using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectFinal.ConnectToDB
{
    public class ConnectToDB
    {
        // .net dataprovider to connect to DB
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlDataAdapter;

        /// <summary>
        /// constructor of class ConnectToDB
        /// </summary>
        public ConnectToDB()
        {
            try
            {
                //inital SqlConnection
                sqlConnection = new SqlConnection(@"Data Source=DESKTOP-DSALA6B\THIENLY;Initial Catalog=DULIEULUUTRU;User ID=sa;Password=18154033");

                // check state of connection. If connection open then close
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }

                //open connection and inital SqlCommand
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Function to execute query and result is Dataset
        /// </summary>
        /// <param name="StrSql">string sql or name of store procedure</param>
        /// <param name="commandType">command type</param>
        /// <param name="errorMessage">error message when have error</param>
        /// <param name="sqlParameters">list parameter</param>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet(string strSql, CommandType commandType, ref string errorMessage, params SqlParameter[] sqlParameters)
        {
            try
            {
                // check state of connection. If connection close then open
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                // inital sqlcommand
                InitalSqlCommand(strSql, commandType, sqlParameters);

                //inital sqlDataAdapter
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                //Inital DataSet and fill data from sqlDataAdapter for dataset
                DataSet dsResult = new DataSet();
                sqlDataAdapter.Fill(dsResult);

                return dsResult;
            }
            catch (Exception exception)
            {
                //Assign error message
                errorMessage = exception.Message;
                return null;
            }
            finally
            {
                //close connection
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        /// <summary>
        /// Function to execute non query and result is bool
        /// </summary>
        /// <param name="StrSql">string sql or name of store procedure</param>
        /// <param name="commandType">command type</param>
        /// <param name="errorMessage">error message when have error</param>
        /// <param name="sqlParameters">list parameter</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string strSql, CommandType commandType, ref string errorMessage, params SqlParameter[] sqlParameters)
        {
            try
            {
                // check state of connection. If connection close then open
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                // inital sqlcommand
                InitalSqlCommand(strSql, commandType, sqlParameters);

                //execute query
                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception exception)
            {
                //Assign error message
                errorMessage = exception.Message;

                return false;
            }
            finally
            {
                //close connection
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        /// <summary>
        /// Inital SqlCommand
        /// </summary>
        /// <param name="StrSql">string sql or name of store procedure</param>
        /// <param name="commandType">command type</param>
        /// <param name="sqlParameters">list parameter</param>
        private void InitalSqlCommand(string strSql, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            //delte parameter then input command text and command type
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = strSql;
            sqlCommand.CommandType = commandType;

            //Check if SqlParameter difference then add parameter for sqlcommand
            if (sqlParameters != null)
            {
                // Add parameter for sqlcommand
                foreach (SqlParameter sqlParameter in sqlParameters)
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                }
            }
        }
    }
}