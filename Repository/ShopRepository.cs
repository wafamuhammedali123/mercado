using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using mercado.Interfaces;
using mercado.Model;

namespace mercado.Repository
{
    public class ShopRepository : IShopRepository
    {
        private string connectionString;
        public ShopRepository()
        {
            connectionString = @"Server=localhost;Database=Market;Trusted_Connection=true";
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public IEnumerable<ShopModel> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<ShopModel>("SELECT * FROM Shops");
            }
        }
        public void Add(ShopModel item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "INSERT INTO Shops (ShopName,Latitude,Longitude,Rating)"
                                 + " VALUES(@ShopName,@Latitude,@Longitude,@Rating)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);

            }
        }
        public void Update(ShopModel item)
        {
            try
            {
                using (IDbConnection dbConnection = GetConnection())
                {
                    string sQuery = @"UPDATE Shops SET
                                     ShopName = @ShopName,
                                     Latitude = @Latitude,
                                     Longitude = @Longitude,
                                     Rating = @Rating
                                     WHERE ShopId = @ShopId";
                    dbConnection.Open();
                    dbConnection.Query(sQuery, item);
                }
            }
            catch (Exception e)
            {
                return;

            }


        }




    }
}

