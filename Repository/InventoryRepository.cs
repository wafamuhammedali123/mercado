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
    public class InventoryRepository
    {
        private string connectionString;
        public InventoryRepository()
        {
            connectionString = @"Server=localhost;Database=Market;Trusted_Connection=true";
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public IEnumerable<InventoryModel> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<InventoryModel>("SELECT * FROM Inventory");
            }
        }
         public void AddInventory(InventoryModel item)
        {
            try {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"INSERT INTO Inventory (ProductName,ShopId,Price)
                                VALUES(@ProductName,@ShopId,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
            }
            catch(Exception e) {
                return;
            }
        }
        public void UpdateInventory(InventoryModel item)
        {

            try {
                using (IDbConnection dbConnection = GetConnection())
                {
                    string sQuery = "UPDATE Inventory SET "
                                    + " ProductName = @ProductName"
                                    + " Price = @Price "
                                    + "WHERE  InventoryId = @InventoryId";
                    dbConnection.Open();
                    dbConnection.Query(sQuery, item);
                }
            }
            catch(Exception e) {
                return;
            }
            
        }
        

        public IEnumerable<Product> SearchInventory(string productName)
        {
            try {
                using (IDbConnection dbConnection = GetConnection())
                {
                    string sQuery = @"
                        SELECT * FROM Inventory i LEFT JOIN Shops s ON(s.ShopId = i.ShopId) WHERE ProductName LIKE '%"+productName+@"%';
                    ";
                    dbConnection.Open();
                    return dbConnection.Query<Product>(sQuery, new {Name = productName});
                }
            }
            catch(Exception e) {
                return null;
            }
        }
    }
}