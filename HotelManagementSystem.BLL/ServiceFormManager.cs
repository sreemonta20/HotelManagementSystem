﻿using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.BLL
{
    public class ServiceFormManager
    {
        #region Variable Declaration

        #endregion

        #region Constructor Overloading

        #endregion

        #region All Methods

        public int GetNextFoodServiceToCustID()
        {
            try
            {
                return FoodServiceToCustomer.GetNextFoodServiceToCustID();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public List<FoodService> GetAllFoodService()
        {
            try
            {
                return FoodService.GetAllFoodService();
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

        public bool SaveIntoFoodServiceToCustomer(FoodServiceToCustomer oFoodServiceToCustomer)
        {
            try
            {
                return FoodServiceToCustomer.SaveIntoFoodServiceToCustomer(oFoodServiceToCustomer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}
