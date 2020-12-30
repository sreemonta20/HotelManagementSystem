using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.DAO
{
    public class FoodService
    {

        #region Variable Declaration
            private string _FoodServiceCode;
            private string _FoodServiceName;
            private string _FSType;
            private double _Price;

        #endregion

        #region Properties

            public string FoodServiceCode
            {
                get { return _FoodServiceCode; }
                set { _FoodServiceCode = value; }
            }

            public string FoodServiceName
            {
                get { return _FoodServiceName; }
                set { _FoodServiceName = value; }
            }

            public string FSType
            {
                get { return _FSType; }
                set { _FSType = value; }
            }

            public double Price
            {
                get { return _Price; }
                set { _Price = value; }
            }
        #endregion

        #region Constructor Overloading

            public FoodService()
            {

            }

            public FoodService(string foodService, string foodServiceName, string fSType, double price)
            {
                FoodServiceCode = foodService;
                FoodServiceName = foodServiceName;
                FSType = fSType;
                Price = price;
            }

        #endregion

        #region All Methods

            public static List<FoodService> GetAllFoodService()
            {
                DBConnection oDBConnection = new DBConnection();
                SqlCommand oSqlCommand = new SqlCommand();
                List<FoodService> FoodServiceCollection = new List<FoodService>();
                string queryString = "Select * From FoodService";

                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    SqlDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                    while (oSqlDataReader.Read())
                    {
                        FoodService oFoodService = new FoodService(oSqlDataReader[0].ToString(), oSqlDataReader[1].ToString(), oSqlDataReader[2].ToString(),
                        Convert.ToDouble(oSqlDataReader[3]));

                        FoodServiceCollection.Add(oFoodService);
                    }
                }
                catch
                {
                    FoodServiceCollection = null;
                }
                finally
                {
                    oDBConnection.CloseConnection();
                }

                return FoodServiceCollection;
            }

        #endregion

    }
}
