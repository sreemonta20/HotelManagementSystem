using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

            

        #endregion
    }
}
