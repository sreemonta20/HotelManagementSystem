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
        private string _ArrivalDate;
        private string _DepartureDate;
        private string _TotalRoomRent;
        private string _PurposeOfArrival;
        
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

            public string ArrivalDate
            {
                get { return _ArrivalDate; }
                set { _ArrivalDate = value; }
            }

            public string DepartureDate
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

        #endregion

        #region Constructor Overloading

            public RoomServiceToCustomer()
            {

            }

            public RoomServiceToCustomer(string roomServiceToCustID, string customerCode, string roomCode, string arrivalDate, string departureDate,
            string totalRoomRent, string purposeOfArrival)
            {

                RoomServiceToCustID = roomServiceToCustID;
                CustomerCode = customerCode;
                RoomCode = roomCode;
                ArrivalDate = arrivalDate;
                DepartureDate = departureDate;
                TotalRoomRent = totalRoomRent;
                PurposeOfArrival = purposeOfArrival;

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
                    string queryString = @"Select MAX(RoomServiceToCustID) as RoomServiceToCustID From RoomServiceToCustomer";

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
                        oSqlDataReader[3].ToString(), oSqlDataReader[4].ToString(), oSqlDataReader[5].ToString(), oSqlDataReader[6].ToString());

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

                String queryString = String.Format(@"Insert Into RoomServiceToCustomer (RoomServiceToCustID, CustomerCode, RoomCode, ArrivalDate, DepartureDate, TotalRoomRent, PurposeOfArrival)
                                            Values
                                            ('" + oRoomServiceToCustomer.RoomServiceToCustID + "', '" + oRoomServiceToCustomer.CustomerCode + "', '" + oRoomServiceToCustomer.RoomCode + "', '"
                                            + oRoomServiceToCustomer.ArrivalDate + "',' " + oRoomServiceToCustomer.DepartureDate + "', '" + oRoomServiceToCustomer.TotalRoomRent + "','" + oRoomServiceToCustomer.PurposeOfArrival + "')");
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
                string queryString = @"Select RoomCode From RoomServiceToCustomer";

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
                                            Where RSC.CustomerCode = '{0}' And RSC.RoomCode = '{1}' And RSC.DepartureDate = ''", customerCode, roomCode);

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

            

            public static bool UpdateRegisterRoomStatusAfterCheckOut(RoomService oRoomService, string customerCode, double rent)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Update RoomServiceToCustomer Set DepartureDate = '" + DateTime.Now +
                        "' , TotalRoomRent=" + rent + " where RoomCode=" + oRoomService.RoomCode + " and CustomerCode='" + customerCode + "'");
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

            public bool UpdateRoomStatusAfterCheckOut(RoomService oRoomService)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                string queryString = @"Update RoomService Set RoomStatus ='Empty' where RoomCode=" + oRoomService.RoomCode + "";
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

            //public static List<Customer> GetAllExistingCustomer()
            //{
            //    DBConnection oDBConnection = new DBConnection();
            //    SqlCommand oSqlCommand = new SqlCommand();
            //    List<Customer> CustomerCollection = new List<Customer>();
            //    string queryString = "SELECT * FROM Customer";

            //    try
            //    {
            //        oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
            //        SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

            //        while (oSqlDataReader.Read())
            //        {
            //            Customer oCustomer = new Customer(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString(),
            //            oSqlDataReader[3].ToString(), oSqlDataReader[4].ToString(), oSqlDataReader[5].ToString(), oSqlDataReader[6].ToString());

            //            CustomerCollection.Add(oCustomer);
            //        }
            //    }
            //    catch
            //    {
            //        CustomerCollection = null;
            //    }
            //    finally
            //    {
            //        oDBConnection.CloseConnection();
            //    }

            //    return CustomerCollection;
            //}

//            public List<RoomService> GetAllRoomNumbersByRoomType(string roomTypeName)
//            {
//                DBConnection oDBConnection = new DBConnection();
//                SqlCommand oSqlCommand = new SqlCommand();
//                List<RoomService> RoomServiceCollection = new List<RoomService>();
//                String queryString = String.Format(@"Select * From RoomService RS
//                                            Inner Join RoomTypeDetails RTD on RTD.RoomTypeCode = RS.RoomTypeCode
//                                            Where RTD.RoomTypeCode = RS.RoomTypeCode And RTD.RoomTypeName = '{0}'", roomTypeName);
//                try
//                {
//                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
//                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

//                    while (oSqlDataReader.Read())
//                    {
//                        RoomService oRoomService = new RoomService(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString());
//                        RoomServiceCollection.Add(oRoomService);
//                    }
//                }
//                catch
//                {
//                    RoomServiceCollection = null;
//                }
//                finally
//                {
//                    oDBConnection.CloseConnection();
//                }

//                return RoomServiceCollection;
//            }

        #endregion
    }
}
