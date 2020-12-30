using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.DAO
{
    public class RoomService
    {
        #region Variable Declaration

            private string _RoomCode;
            private string _RoomTypeCode;
            private string _RoomStatus;
            private string _RoomTypeName;

        #endregion

        #region Properties

            public string RoomCode
            {
                get { return _RoomCode; }
                set { _RoomCode = value; }
            }


            public string RoomTypeCode
            {
                get { return _RoomTypeCode; }
                set { _RoomTypeCode = value; }
            }


            public string RoomStatus
            {
                get { return _RoomStatus; }
                set { _RoomStatus = value; }
            }

            //public string RoomTypeName
            //{
            //    get { return _RoomTypeName; }
            //    set { _RoomTypeName = value; }
            //}

        #endregion

        #region Constructor Overloading

            public RoomService()
            {

            }

            public RoomService(string roomCode, string roomTypeCode, string roomStatus)
            {

                RoomCode = roomCode;
                RoomTypeCode = roomTypeCode;
                RoomStatus = roomStatus;
            }

        #endregion

        #region All Methods

            public static List<RoomService> GetAllRoomNumbers()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<RoomService> RoomServiceCollection = new List<RoomService>();
                string queryString = "SELECT * FROM RoomService";

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    while (oSqlDataReader.Read())
                    {
                        RoomService oRoomService = new RoomService(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString());
                        RoomServiceCollection.Add(oRoomService);
                    }
                }
                catch
                {
                    RoomServiceCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return RoomServiceCollection;
            }

            public static List<RoomService> GetAllRoomNumbersByRoomType(string roomTypeName)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<RoomService> RoomServiceCollection = new List<RoomService>();
                String queryString = String.Format(@"Select * From RoomService RS
                                            Inner Join RoomTypeDetails RTD on RTD.RoomTypeCode = RS.RoomTypeCode
                                            Where RTD.RoomTypeCode = RS.RoomTypeCode And RoomStatus = 'Empty' And RTD.RoomTypeName = '{0}'", roomTypeName);
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    while (oSqlDataReader.Read())
                    {
                        RoomService oRoomService = new RoomService(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString());
                        RoomServiceCollection.Add(oRoomService);
                    }
                }
                catch
                {
                    RoomServiceCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return RoomServiceCollection;
            }

            public static double GetRoomRent(string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                double roomRent = 0;
                String queryString = String.Format(@"Select RTD.RoomCost From RoomService RS
                                                   Inner Join RoomTypeDetails RTD On RTD.RoomTypeCode = RS.RoomTypeCode
                                                   Where RS.RoomCode = '{0}'", roomCode);
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    if (oSqlDataReader.Read())
                    {
                        roomRent = Convert.ToDouble(oSqlDataReader[0]);
                    }
                }
                catch
                {
                    roomRent = 0;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return roomRent;
            }

            public static bool UpdateRoomStatusAfterCheckOut(string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Update RoomService Set RoomStatus = 'Empty'
                                            Where RoomCode = '{0}'", roomCode);
                try
                {

                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    int affectedRows = oSqlCommand.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }
            }

            public static bool UpdateRoomStatusToRegistered(string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Update RoomService Set RoomStatus = 'Registered'
                                            Where RoomCode = '{0}'", roomCode);
                try
                {

                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    int affectedRows = oSqlCommand.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }
            }

            public static bool UpdateRoomStatusToBooked(string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Update RoomService Set RoomStatus = 'Booked'
                                            Where RoomCode = '{0}'", roomCode);
                try
                {

                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    int affectedRows = oSqlCommand.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }
            }

            public static List<RoomService> GetAllBookedRoomNumbers()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<RoomService> RoomServiceCollection = new List<RoomService>();
                string queryString = "SELECT * FROM RoomService Where RoomStatus = 'Booked'";

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    while (oSqlDataReader.Read())
                    {
                        RoomService oRoomService = new RoomService(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString());
                        RoomServiceCollection.Add(oRoomService);
                    }
                }
                catch
                {
                    RoomServiceCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return RoomServiceCollection;
            }

        #endregion
    }
}
