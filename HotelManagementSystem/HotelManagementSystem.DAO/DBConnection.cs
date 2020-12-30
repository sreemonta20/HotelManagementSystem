using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CrystalDecisions.Shared;

namespace HotelManagementSystem.DAO
{
    [Serializable]
    public class DBConnection
    {
        #region Variable Declaration & Initialization

        private string connectionString = ConfigurationManager.ConnectionStrings["hms"].ConnectionString;
        private SqlConnection sqlConn;

        #endregion

        #region Constructor Overloading

            public DBConnection()
            {

            }

        #endregion

        #region All Methods

            public SqlCommand CreateSqlCommand(string commandString)
            {
                try
                {
                    sqlConn = new SqlConnection(connectionString);
                    sqlConn.Open();
                    return new SqlCommand(commandString, sqlConn);
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }

            public void CloseConnection()
            {
                sqlConn.Close();
            }

            public ConnectionInfo CreateConnectionForReport()
            {
                ConnectionInfo ConnInfo = new ConnectionInfo();

                string[] ff;
                string[] ss;

                ff = connectionString.Split('=');

                ss = ff[1].Split(';');
                ConnInfo.ServerName = ss[0];

                ss = ff[3].Split(';');
                ConnInfo.DatabaseName = ss[0];

                ConnInfo.UserID = "sa";
                ConnInfo.Password = "sa";
                ConnInfo.IntegratedSecurity = true;
                return ConnInfo;
            }

        #endregion
    }
}
