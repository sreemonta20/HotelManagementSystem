using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.BLL
{
    public class CustomerRegistrationManager
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

        public int GetNextCustomerCode()
        {
            try
            {
                return Customer.GetNextCustomerCode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetNextRoomServiceToCustID()
        {
            try
            {
                return RoomServiceToCustomer.GetNextRoomServiceToCustID();
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

        public string SaveCustomerInRegisteredRoom(bool isNewCustomer, Customer oCustomer, RoomServiceToCustomer oRoomServiceToCustomer)
        {
            bool status = true;
            try
            {
                
                    if (oCustomer != null && oRoomServiceToCustomer != null && isNewCustomer == true)
                    {
                        status = Customer.SaveIntoCustomer(oCustomer);
                    }
                    else if (oCustomer == null && oRoomServiceToCustomer != null && isNewCustomer == false)
                    {
                        status = true;
                    }
                    if (status)
                    {
                        status = RoomServiceToCustomer.SaveIntoRoomServiceToCustomer(oRoomServiceToCustomer);
                    }
                    if (status)
                    {
                        status = RoomService.UpdateRoomStatusToRegistered(oRoomServiceToCustomer.RoomCode);
                        return "Customer with customer ID " + oRoomServiceToCustomer.CustomerCode + ", is registered at room number " + oRoomServiceToCustomer.RoomCode.ToString();
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
