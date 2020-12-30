using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.DAO
{
    public class RoomTypeDetails
    {
        #region Variable Declaration

            private string _RoomTypeCode;
            private string _RoomTypeName;
            private double _RoomCost;
        
        #endregion

        #region Properties

            public string RoomTypeCode
            {
                get { return _RoomTypeCode; }
                set { _RoomTypeCode = value; }
            }


            public string RoomTypeName
            {
                get { return _RoomTypeName; }
                set { _RoomTypeName = value; }
            }


            public double RoomCost
            {
                get { return _RoomCost; }
                set { _RoomCost = value; }
            }

        #endregion

        #region Constructor Overloading

            public RoomTypeDetails()
            {

            }

            public RoomTypeDetails(string roomTypeCode, string roomTypeName, double roomCost)
            {

                RoomTypeCode = roomTypeCode;
                RoomTypeName = roomTypeName;
                RoomCost = roomCost;
            }

        #endregion

        #region All Methods

            public static List<RoomTypeDetails> GetRoomTypes()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<RoomTypeDetails> RoomTypeDetailsCollection = new List<RoomTypeDetails>();
                string queryString = "SELECT * FROM RoomTypeDetails";

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    while (oSqlDataReader.Read())
                    {
                        RoomTypeDetails oRoomTypeDetails = new RoomTypeDetails(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), Convert.ToDouble(oSqlDataReader[2]));
                        RoomTypeDetailsCollection.Add(oRoomTypeDetails);
                    }
                }
                catch
                {
                    RoomTypeDetailsCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return RoomTypeDetailsCollection;
            }

        #endregion
    }
}
