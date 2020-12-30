using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.DAO
{
    public class Booking
    {
        #region Variable Declaration

            private string _BookingCode;
            private string _RoomCode;
            private DateTime _BookingDate;
            private DateTime _BookingEndDate;
            private string _CustomerName;
            private string _Address;
            private string _ContactNo;
            private string _EmailAddress;
            private string _Remark;

        #endregion

        #region Properties

            public string BookingCode
            {
                get { return _BookingCode; }
                set { _BookingCode = value; }
            }


            public string RoomCode
            {
                get { return _RoomCode; }
                set { _RoomCode = value; }
            }

            public DateTime BookingDate
            {
                get { return _BookingDate; }
                set { _BookingDate = value; }
            }

            public DateTime BookingEndDate
            {
                get { return _BookingEndDate; }
                set { _BookingEndDate = value; }
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

        #region Method Overloading

        #endregion

        #region All Methods

            public static int GetNextBookingCode()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                object bookingCode = null;
                try
                {
                    string queryString = @"Select Max(Convert(Int,REPLACE(BookingCode, 'CC-', ''))) from Booking";
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    bookingCode = oSqlCommand.ExecuteScalar();
                    if (bookingCode != null)
                        return Convert.ToInt32(bookingCode) + 1;
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

            public static bool BookRoom(Booking oBooking)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();

                String queryString = String.Format(@"Insert Into Booking (BookingCode, RoomCode, BookingDate, BookingEndDate, CustomerName, Address, ContactNo, EmailAddress, Remark)
                                            Values
                                            ('" + oBooking.BookingCode + "', '" + oBooking.RoomCode + "', '" + oBooking.BookingDate + "', '"
                                            + oBooking.BookingEndDate + "',' " + oBooking.CustomerName + "', '" + oBooking.Address + "','" + oBooking.ContactNo + "', '" + oBooking.EmailAddress + "', '" + oBooking.Remark + "')");
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

            public static bool FreeDataFromBookingTblByRoomCode(string roomCode)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                String queryString = String.Format(@"Delete From Booking Where RoomCode = '{0}' And Convert(Date, BookingEndDate) < Convert(Date, Getdate())", roomCode);
                
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
