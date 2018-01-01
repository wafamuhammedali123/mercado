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
    public class InventoryRepository : IInventoryRepository
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
        public IEnumerable<ShopModel> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<ShopModel>("SELECT * FROM Shop");
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

        IEnumerable<InventoryModel> IInventoryRepository.GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Add(InventoryModel item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(InventoryModel item)
        {
            throw new System.NotImplementedException();
        }
    }
}