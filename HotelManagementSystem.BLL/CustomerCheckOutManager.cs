using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.BLL
{
    public class CustomerCheckOutManager
    {
        #region Variable Declaration

        double totalDaysRoomService, totaldays, roomRent;
        DateTime arrivalDateOfCustomer, checkoutDateOfCustomer;
        TimeSpan dateDifference;
        bool checkoutResult;
        //RoomService oRoomService = new RoomService();
        #endregion

        #region Constructor Overloading

        #endregion

        #region All Methods
            public List<RoomServiceToCustomer> GetRoomCodesWithCustomer()
            {
                try
                {
                    return RoomServiceToCustomer.GetRoomCodesWithCustomer();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public Customer GetCustomerByRoomCode(String roomCode)
            {
                try
                {
                    return Customer.GetCustomerByRoomCode(roomCode);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public bool CustomerCheckOut(String customerCode, String roomCode)
            {
                try
                {
                    totaldays = GetTotalDaysRoomServiceCalculationForRegisteredCustomer(customerCode, roomCode);
                    roomRent = RoomService.GetRoomRent(roomCode);
                    roomRent = roomRent * totaldays;
                    checkoutResult = RoomServiceToCustomer.UpdateRegisterRoomStatusAfterCheckOut(customerCode, roomCode, roomRent);
                    if (checkoutResult)
                    {
                        checkoutResult = RoomService.UpdateRoomStatusAfterCheckOut(roomCode);
                    }
                    
                    return checkoutResult;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            private double GetTotalDaysRoomServiceCalculationForRegisteredCustomer(String customerCode, String roomCode)
            {
                arrivalDateOfCustomer = RoomServiceToCustomer.GetCustomerArrivalDate(customerCode, roomCode);
                checkoutDateOfCustomer = DateTime.Now;
                dateDifference = checkoutDateOfCustomer.Subtract(arrivalDateOfCustomer);
                totalDaysRoomService = dateDifference.Days;
                try
                {
                    if (totalDaysRoomService > 0)
                    {
                        if ((Convert.ToInt32(arrivalDateOfCustomer.Hour) > 6) && (arrivalDateOfCustomer.ToString().IndexOf("PM") == -1))
                        {
                            totalDaysRoomService -= 1;
                        }
                        else if ((Convert.ToInt32(checkoutDateOfCustomer.Hour) > 12) && (checkoutDateOfCustomer.ToString().IndexOf("AM") == -1))
                        {
                            totalDaysRoomService += 1;
                        }
                    }
                    else
                    {
                        totalDaysRoomService = 1;
                    }
                    return totalDaysRoomService;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public bool CheckActiveInactive(String customerCode, String roomCode)
            {
                try
                {
                    checkoutResult = RoomServiceToCustomer.RSC_SetInactiveStatusAfterCheckOut(customerCode, roomCode);
                    if (checkoutResult)
                    {
                        checkoutResult = FoodServiceToCustomer.FSC_SetInactiveStatusAfterCheckOut(customerCode, roomCode);
                    }
                    return checkoutResult;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        #endregion

    }
}
