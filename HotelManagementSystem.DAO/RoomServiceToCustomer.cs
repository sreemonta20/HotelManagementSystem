using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.DAO
{
    public class RoomServiceToCustomer
    {
        #region Variable Declaration

        private string _RoomServiceToCustID;
        private string _CustomerCode;
        private string _RoomCode;
        private DateTime _ArrivalDate;
        private DateTime _DepartureDate;
        private string _TotalRoomRent;
        private string _PurposeOfArrival;
        private string _Status;
        
        #endregion

        #region Properties

            public string RoomServiceToCustID
            {
                get { return _RoomServiceToCustID; }
                set { _RoomServiceToCustID = value; }
            }


            public string CustomerCode
            {
                get { return _CustomerCode; }
                set { _CustomerCode = value; }
            }


            public string RoomCode
            {
                get { return _RoomCode; }
                set { _RoomCode = value; }
            }

            public DateTime ArrivalDate
            {
                get { return _ArrivalDate; }
                set { _ArrivalDate = value; }
            }

            public DateTime DepartureDate
            {
                get { return _DepartureDate; }
                set { _DepartureDate = value; }
            }

            public string TotalRoomRent
            {
                get { return _TotalRoomRent; }
                set { _TotalRoomRent = value; }
            }

            public string PurposeOfArrival
            {
                get { return _PurposeOfArrival; }
                set { _PurposeOfArrival = value; }
            }
            public string Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

        #endregion

        #region Constructor Overloading

            public RoomServiceToCustomer()
            {

            }

            public RoomServiceToCustomer(string roomServiceToCustID, string customerCode, string roomCode, DateTime arrivalDate, DateTime departureDate,
            string totalRoomRent, string purposeOfArrival, string status)
            {

                RoomServiceToCustID = roomServiceToCustID;
                CustomerCode = customerCode;
                RoomCode = roomCode;
                ArrivalDate = arrivalDate;
                DepartureDate = departureDate;
                TotalRoomRent = totalRoomRent;
                PurposeOfArrival = purposeOfArrival;
                Status = status;

            }

        #endregion

        #region All Methods

            public static int GetNextRoomServiceToCustID()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                object roomServiceToCustID = null;
                try
                {
                    //string queryString = @"Select MAX(RoomServiceToCustID) as RoomServiceToCustID From RoomServiceToCustomer";
                    string queryString = @"Select Max(Convert(Int,REPLACE(RoomServiceToCustID, 'RSC-', ''))) from RoomServiceToCustomer";
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    roomServiceToCustID = oSqlCommand.ExecuteScalar();
                    if (roomServiceToCustID != null)
                        return Convert.ToInt32(roomServiceToCustID) + 1;
                    else
                        return 1;
                }
                catch
                {
                    return 1;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }
            }

            public static List<RoomServiceToCustomer> GetAllRoomServiceToCustomer()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<RoomServiceToCustomer> RoomServiceToCustomerCollection = new List<RoomServiceToCustomer>();
                string queryString = "SELECT * FROM RoomServiceToCustomer";

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    while (oSqlDataReader.Read())
                    {
                        RoomServiceToCustomer oRoomServiceToCustomer = new RoomServiceToCustomer(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString(),
                        Convert.ToDateTime(oSqlDataReader[3]), Convert.ToDateTime(oSqlDataReader[4]), oSqlDataReader[5].ToString(), oSqlDataReader[6].ToString(), oSqlDataReader[7].ToString());

                        RoomServiceToCustomerCollection.Add(oRoomServiceToCustomer);
                    }
                }
                catch
                {
                    RoomServiceToCustomerCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return RoomServiceToCustomerCollection;
            }

            public static bool SaveIntoRoomServiceToCustomer(RoomServiceToCustomer oRoomServiceToCustomer)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();

                String queryString = String.Format(@"Insert Into RoomServiceToCustomer (RoomServiceToCustID, CustomerCode, RoomCode, ArrivalDate, DepartureDate, TotalRoomRent, PurposeOfArrival, Status)
                                            Values
                                            ('" + oRoomServiceToCustomer.RoomServiceToCustID + "', '" + oRoomServiceToCustomer.CustomerCode + "', '" 
                                                + oRoomServiceToCustomer.RoomCode + "', '" + oRoomServiceToCustomer.ArrivalDate + "','', '" 
                                                + oRoomServiceToCustomer.TotalRoomRent + "','" + oRoomServiceToCustomer.PurposeOfArrival + "','" 
                                                +  oRoomServiceToCustomer.Status  + "')");
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

            public static bool UpdateRoomStatus(RoomService oRoomService)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                string queryString = @"Update RoomService Set RoomStatus = 'Registered' where RoomCode = '" + oRoomService.RoomCode + "'";
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

            public static List<RoomServiceToCustomer> GetRoomCodesWithCustomer()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<RoomServiceToCustomer> RoomServiceToCustomerCollection = null;
                string queryString = @"Select RoomCode From RoomServiceToCustomer  where DepartureDate =''";

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    RoomServiceToCustomerCollection = new List<RoomServiceToCustomer>();
                    RoomServiceToCustomer oRoomServiceToCustomer;
                    while (oSqlDataReader.Read())
                    {
                        oRoomServiceToCustomer = new RoomServiceToCustomer();
                        oRoomServiceToCustomer.RoomCode = oSqlDataReader[0].ToString();
                        RoomServiceToCustomerCollection.Add(oRoomServiceToCustomer);
                    }
                }
                catch
                {
                    RoomServiceToCustomerCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return RoomServiceToCustomerCollection;
            }

            public static DateTime GetCustomerArrivalDate(string customerCode, string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                DateTime oDateTime = new DateTime();
                String queryString = String.Format(@"Select RSC.ArrivalDate From RoomServiceToCustomer RSC
                                            Where RSC.CustomerCode = '{0}' And RSC.RoomCode = '{1}' And RSC.DepartureDate = '1900-01-01 00:00:00.000'", customerCode, roomCode);

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    if (oSqlDataReader.Read())
                    {
                        oDateTime = Convert.ToDateTime(oSqlDataReader[0]);
                    }
                }
                catch
                {
                    oDateTime = DateTime.Now;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return oDateTime;
            }



            public static bool UpdateRegisterRoomStatusAfterCheckOut(string customerCode, string roomCode, double roomRent)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Update RoomServiceToCustomer Set DepartureDate = '" + DateTime.Now +
                        "' , TotalRoomRent=" + roomRent + " where RoomCode=" + roomCode + " and CustomerCode='" + customerCode + "'");
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

            public static bool RSC_SetInactiveStatusAfterCheckOut(string customerCode, string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Update RoomServiceToCustomer Set Status = '" 
                    + "Inactive" + "' Where CustomerCode = '{0}' And RoomCode = '{1}'",customerCode, roomCode);
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

        #endregion
    }
}
