using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace HotelManagementSystem.DAO
{
    public class User
    {
        #region VariableDeclaration

        private int _UserCode;
        private string _Name;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Address;
        private string _UserName;
        private string _Password;
        private string _UserType;

        #endregion

        #region Properties

        public int UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }

        #endregion

        #region Constructor Overloading

        public User()
        {

        }

        public User(string name, string firstName, string lastName, string email, string address, string userName, string password, string userType)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            UserName = userName;
            Password = password;
            UserType = userType;
        }

        #endregion

        #region All Methods

            public static bool RegisterUser(string name, string firstName, string lastName, string userEmail, string address, string userName, string password, string userType)
            {

                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                string queryString = "spRegisterUser";
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    oSqlCommand.CommandType = CommandType.StoredProcedure;

                    string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                    SqlParameter paramRegName = new SqlParameter("@Name", name);
                    SqlParameter paramRegFirstName = new SqlParameter("@FirstName", firstName);
                    SqlParameter paramRegLastName = new SqlParameter("@LastName", lastName);
                    SqlParameter paramRegEmail = new SqlParameter("@Email", userEmail);
                    SqlParameter paramRegAddress = new SqlParameter("@Address", address);
                    SqlParameter paramRegUsername = new SqlParameter("@UserName", userName);
                    SqlParameter paramRegPassword = new SqlParameter("@Password", encryptedPassword);
                    SqlParameter paramRegUserType = new SqlParameter("@UserType", userType);

                    oSqlCommand.Parameters.Add(paramRegName);
                    oSqlCommand.Parameters.Add(paramRegFirstName);
                    oSqlCommand.Parameters.Add(paramRegLastName);
                    oSqlCommand.Parameters.Add(paramRegEmail);
                    oSqlCommand.Parameters.Add(paramRegAddress);
                    oSqlCommand.Parameters.Add(paramRegUsername);
                    oSqlCommand.Parameters.Add(paramRegPassword);
                    oSqlCommand.Parameters.Add(paramRegUserType);


                    int ReturnCode = (int)oSqlCommand.ExecuteScalar();
                    if (ReturnCode == -1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public static bool AuthenticateUser(string userName, string password)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                string queryString = "spAuthenticateUser";
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    oSqlCommand.CommandType = CommandType.StoredProcedure;

                    string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                    SqlParameter paramUsername = new SqlParameter("@UserName", userName);
                    SqlParameter paramPassword = new SqlParameter("@Password", encryptedPassword);

                    oSqlCommand.Parameters.Add(paramUsername);
                    oSqlCommand.Parameters.Add(paramPassword);


                    int ReturnCode = (int)oSqlCommand.ExecuteScalar();
                    return ReturnCode == 1;

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public static string GetUserType(string userName, string password)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                object userType = null;
                string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                String queryString = String.Format(@"Select UserType from [User] Where UserName = '{0}' And [Password] = '{1}'", userName, encryptedPassword);
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    userType = oSqlCommand.ExecuteScalar();
                    if (userType != null)
                    {
                        return Convert.ToString(userType);
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {
                    return "";
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

            }

            
            public static bool ChangeUserPassword(User oUser)
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                oUser.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(oUser.Password, "SHA1");
                string queryString = @"Update [User] Set Password = '" + oUser.Password + "' Where UserName = '" + oUser.UserName + "'";
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
