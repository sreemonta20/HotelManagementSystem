using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.DAO
{
    public class FoodServiceToCustomer
    {
        #region Variable Declaration

        private string _FoodServiceToCustID;
        private string _CustomerCode;
        private string _RoomCode;
        private string _FoodServiceName;
        private double _FoodPrice;
        private double _Quantity;
        private DateTime _ServiceDate;
        private string _Status;

        #endregion

        #region Properties

            public string FoodServiceToCustID
            {
                get { return _FoodServiceToCustID; }
                set { _FoodServiceToCustID = value; }
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

            public string FoodServiceName
            {
                get { return _FoodServiceName; }
                set { _FoodServiceName = value; }
            }

            public double FoodPrice
            {
                get { return _FoodPrice; }
                set { _FoodPrice = value; }
            }

            public double Quantity
            {
                get { return _Quantity; }
                set { _Quantity = value; }
            }

            public DateTime ServiceDate
            {
                get { return _ServiceDate; }
                set { _ServiceDate = value; }
            }

            public string Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

        #endregion

        #region Constructor Overloading

            public FoodServiceToCustomer()
            {

            }

            public FoodServiceToCustomer(string foodServiceToCustID, string customerCode, string roomCode, string foodServiceName, double foodPrice,
            double quantity, DateTime serviceDate, string status)
            {
                FoodServiceToCustID = foodServiceToCustID;
                CustomerCode = customerCode;
                RoomCode = roomCode;
                FoodServiceName = foodServiceName;
                FoodPrice = foodPrice;
                Quantity = quantity;
                ServiceDate = serviceDate;
                Status = status;
            }

        #endregion

        #region All Methods

            public static int GetNextFoodServiceToCustID()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                object foodServiceToCustID = null;
                try
                {
                    //string queryString = @"Select MAX(FoodServiceToCustID) as FoodServiceToCustID From FoodServiceToCustomer";
                    string queryString = @"Select Max(Convert(Int,REPLACE(FoodServiceToCustID, 'FSC-', ''))) from FoodServiceToCustomer";
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    foodServiceToCustID = oSqlCommand.ExecuteScalar();
                    if (foodServiceToCustID != null)
                        return Convert.ToInt32(foodServiceToCustID) + 1;
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


            public static bool SaveIntoFoodServiceToCustomer(FoodServiceToCustomer oFoodServiceToCustomer)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();

                String queryString = String.Format(@"Insert Into FoodServiceToCustomer (FoodServiceToCustID, CustomerCode, RoomCode, FoodServiceName, FoodPrice, Quantity, ServiceDate, Status)
                                            Values
                                            ('" + oFoodServiceToCustomer.FoodServiceToCustID + "', '" + oFoodServiceToCustomer.CustomerCode + "', '" + oFoodServiceToCustomer.RoomCode + "', '"
                                            + oFoodServiceToCustomer.FoodServiceName + "',' " + oFoodServiceToCustomer.FoodPrice + "', '" + oFoodServiceToCustomer.Quantity + "','"
                                            + oFoodServiceToCustomer.ServiceDate + "','" + oFoodServiceToCustomer.Status  + "')");
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

            public static bool FSC_SetInactiveStatusAfterCheckOut(string customerCode, string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Update FoodServiceToCustomer Set Status = '"
                    + "Inactive" + "' Where CustomerCode = '{0}' And RoomCode = '{1}'", customerCode, roomCode);
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

//            public static bool UpdateRoomStatus(RoomService oRoomService)
//            {
//                DBConnection oDBConnection = new DBConnection();
//                SqlCommand oSqlCommand = new SqlCommand();
//                string queryString = @"Update RoomService Set RoomStatus = 'Registered' where RoomCode = '" + oRoomService.RoomCode + "'";
//                try
//                {

//                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
//                    int affectedRows = oSqlCommand.ExecuteNonQuery();
//                    if (affectedRows > 0)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                catch
//                {
//                    return false;
//                }
//                finally
//                {
//                    oDBConnection.CloseConnection();
//                }
//            }

//            public static List<RoomServiceToCustomer> GetRoomCodesWithCustomer()
//            {
//                DBConnection oDBConnection = new DBConnection();
//                SqlCommand oSqlCommand = new SqlCommand();
//                List<RoomServiceToCustomer> RoomServiceToCustomerCollection = null;
//                string queryString = @"Select RoomCode From RoomServiceToCustomer";

//                try
//                {
//                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
//                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

//                    RoomServiceToCustomerCollection = new List<RoomServiceToCustomer>();
//                    RoomServiceToCustomer oRoomServiceToCustomer;
//                    while (oSqlDataReader.Read())
//                    {
//                        oRoomServiceToCustomer = new RoomServiceToCustomer();
//                        oRoomServiceToCustomer.RoomCode = oSqlDataReader[0].ToString();
//                        RoomServiceToCustomerCollection.Add(oRoomServiceToCustomer);
//                    }
//                }
//                catch
//                {
//                    RoomServiceToCustomerCollection = null;
//                }
//                finally
//                {
//                    oDBConnection.CloseConnection();
//                }

//                return RoomServiceToCustomerCollection;
//            }

//            public static DateTime GetCustomerArrivalDate(string customerCode, string roomCode)
//            {
//                DBConnection oDBConnection = new DBConnection();
//                SqlCommand oSqlCommand = new SqlCommand();
//                DateTime oDateTime = new DateTime();
//                String queryString = String.Format(@"Select RSC.ArrivalDate From RoomServiceToCustomer RSC
//                                            Where RSC.CustomerCode = '{0}' And RSC.RoomCode = '{1}' And RSC.DepartureDate = ''", customerCode, roomCode);

//                try
//                {
//                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
//                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

//                    if (oSqlDataReader.Read())
//                    {
//                        oDateTime = Convert.ToDateTime(oSqlDataReader[0]);
//                    }
//                }
//                catch
//                {
//                    oDateTime = DateTime.Now;
//                }
//                finally
//                {
//                    oDBConnection.CloseConnection();
//                }

//                return oDateTime;
//            }

//            public static bool UpdateRegisterRoomStatusAfterCheckOut(RoomService oRoomService, string customerCode, double rent)
//            {
//                DBConnection oDBConnection = new DBConnection();
//                SqlCommand oSqlCommand = new SqlCommand();
//                String queryString = String.Format(@"Update RoomServiceToCustomer Set DepartureDate = '" + DateTime.Now +
//                        "' , TotalRoomRent=" + rent + " where RoomCode=" + oRoomService.RoomCode + " and CustomerCode='" + customerCode + "'");
//                try
//                {

//                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
//                    int affectedRows = oSqlCommand.ExecuteNonQuery();

//                    if (affectedRows > 0)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                catch
//                {
//                    return false;
//                }
//                finally
//                {
//                    oDBConnection.CloseConnection();
//                }
//            }

//            public bool UpdateRoomStatusAfterCheckOut(RoomService oRoomService)
//            {
//                DBConnection oDBConnection = new DBConnection();
//                SqlCommand oSqlCommand = new SqlCommand();
//                string queryString = @"Update RoomService Set RoomStatus ='Empty' where RoomCode=" + oRoomService.RoomCode + "";
//                try
//                {

//                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
//                    int affectedRows = oSqlCommand.ExecuteNonQuery();

//                    if (affectedRows > 0)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                catch
//                {
//                    return false;
//                }
//                finally
//                {
//                    oDBConnection.CloseConnection();
//                }
//            }

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
