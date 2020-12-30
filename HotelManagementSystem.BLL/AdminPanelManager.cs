using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.BLL
{
    public class AdminPanelManager
    {
        #region Variable Declaration

        #endregion

        #region Constructor Overloading

        #endregion

        #region All Methods


        public List<RoomService> GetAllBookedRoomNumbers()
        {
            try
            {
                return RoomService.GetAllBookedRoomNumbers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool FreeDataFromBookingTblByRoomCode(string roomCode)
        {
            try
            {
                return Booking.FreeDataFromBookingTblByRoomCode(roomCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateRoomStatusAfterFreeingBookingTable(string roomCode)
        {
            try
            {
                return RoomService.UpdateRoomStatusAfterCheckOut(roomCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
