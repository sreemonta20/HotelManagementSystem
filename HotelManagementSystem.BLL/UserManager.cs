using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Security;
using HotelManagementSystem.DAO;

namespace HotelManagementSystem.BLL
{
    public class UserManager
    {
        #region Variable Declaration
        
        #endregion

        #region Constructor Overloading
        #endregion

        #region All Methods

            public bool CheckRegisterUser(String name, String firstName, String lastName, String userEmail, String address, String userName, String password, String userType)
            {
                try
                {
                    return User.RegisterUser(name, firstName, lastName, userEmail, address, userName, password, userType);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public bool CheckAuthenticateUser(String userName, String password)
            {
                try
                {
                    return User.AuthenticateUser(userName, password);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public string GetUserType(String userName, String password)
            {
                try
                {
                    return User.GetUserType(userName, password);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public bool ChangeUserPassword(User oUser)
            {
                try
                {
                    return User.ChangeUserPassword(oUser);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        #endregion
    }
}
