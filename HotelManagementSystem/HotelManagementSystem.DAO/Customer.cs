using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.DAO
{
    public class Customer
    {
        #region Variable Declaration

        private string _CustomerCode;
        private string _UserCode;
        private string _CustomerName;
        private string _Address;
        private string _ContactNo;
        private string _EmailAddress;
        private string _Remark;
        
        #endregion

        #region Properties

            public string CustomerCode
            {
                get { return _CustomerCode; }
                set { _CustomerCode = value; }
            }


            public string UserCode
            {
                get { return _UserCode; }
                set { _UserCode = value; }
            }


            public string CustomerName
            {
                get { return _CustomerName; }
                set { _CustomerName = value; }
            }

            public string Address
            {
                get { return _Address; }
                set { _Address = value; }
            }

            public string ContactNo
            {
                get { return _ContactNo; }
                set { _ContactNo = value; }
            }

            public string EmailAddress
            {
                get { return _EmailAddress; }
                set { _EmailAddress = value; }
            }

            public string Remark
            {
                get { return _Remark; }
                set { _Remark = value; }
            }

        #endregion

        #region Constructor Overloading

            public Customer()
            {

            }

            public Customer(string customerCode, string userCode, string customerName, string address, string contactNo, string emailAddress, string remark)
            {

                CustomerCode = customerCode;
                UserCode = userCode;
                CustomerName = customerName;
                Address = address;
                ContactNo = contactNo;
                EmailAddress = emailAddress;
                Remark = remark;

            }

        #endregion

        #region All Methods

            public static int GetNextCustomerCode()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                object customerCode = null;
                try
                {
                    string queryString = @"Select MAX(CustomerCode) as CustomerCode From Customer";

                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    customerCode = oSqlCommand.ExecuteScalar();
                    if (customerCode != null)
                        return Convert.ToInt32(customerCode) + 1;
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

            public static List<Customer> GetAllCustomers()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<Customer> CustomerCollection = new List<Customer>();
                string queryString = "SELECT * FROM Customer";

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    while (oSqlDataReader.Read())
                    {
                        Customer oCustomer = new Customer(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString(),
                        oSqlDataReader[3].ToString(), oSqlDataReader[4].ToString(), oSqlDataReader[5].ToString(), oSqlDataReader[6].ToString());

                        CustomerCollection.Add(oCustomer);
                    }
                }
                catch
                {
                    CustomerCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return CustomerCollection;
            }

            public static bool SaveIntoCustomer(Customer oCustomer)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();

                String queryString = String.Format(@"Insert Into Customer (CustomerCode, UserCode, CustomerName, Address, ContactNo, EmailAddress, Remark)
                                            Values
                                            ('" + oCustomer.CustomerCode + "', '" + oCustomer.UserCode + "', '" + oCustomer.CustomerName + "', '"
                                            + oCustomer.Address + "',' " + oCustomer.ContactNo + "', '" + oCustomer.EmailAddress + "','" + oCustomer.Remark + "')");
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

            public static Customer GetCustomerByRoomCode(string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                Customer oCustomer = new Customer();
                String queryString = String.Format(@"Select C.CustomerCode, C.CustomerName From RoomServiceToCustomer RSC
                                            Inner Join Customer C on C.CustomerCode = RSC.CustomerCode
                                            Where RSC.RoomCode = '{0}'", roomCode);
                //And RSC.DepartureDate = ''
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    if (oSqlDataReader.Read())
                    {

                        oCustomer.CustomerCode = oSqlDataReader[0].ToString();
                        oCustomer.CustomerName = oSqlDataReader[1].ToString();
                    }
                }
                catch
                {
                    oCustomer = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return oCustomer;
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
