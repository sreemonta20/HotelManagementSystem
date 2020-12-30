using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.BLL
{
    public class CustomerBookingUIManager
    {
        #region Variable declaration



        #endregion

        #region Constructor Overloading



        #endregion

        #region All Methods

        public List<RoomTypeDetails> GetAllRoomTypeDetails()
        {
            try
            {
                return RoomTypeDetails.GetRoomTypes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<RoomService> GetAllRoomNumbersByRoomType(String roomTypeName)
        {
            try
            {
                return RoomService.GetAllRoomNumbersByRoomType(roomTypeName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int GetNextBookingCode()
        {
            try
            {
                return Booking.GetNextBookingCode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Customer> GetAllExistingCustomer()
        {
            try
            {
                return Customer.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BookRoom(Booking oBooking)
        {
            bool status = false;
            try
            {

                    if (oBooking != null)
                    {
                        status = Booking.BookRoom(oBooking);
                    }
                    if (status)
                    {
                        status = RoomService.UpdateRoomStatusToBooked(oBooking.RoomCode);
                        return "Customer is booked at room number " + oBooking.RoomCode.ToString();
                    }
                    return "null";
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
