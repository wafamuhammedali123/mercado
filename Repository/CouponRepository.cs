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
    public class CouponRepository : ICouponRepository
    {
        private string connectionString;
        public CouponRepository()
        {
            connectionString = @"Server=localhost;Database=Market;Trusted_Connection=true";
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public IEnumerable<CouponModel> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<CouponModel>("SELECT * FROM Coupon");
            }
        }
         public void Add(CouponModel item)
        {
            try {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"INSERT INTO Coupon (CouponId,InventoryId,UserId,Validity)
                                VALUES(@CouponId,@InventoryId,@UserId,@Validity)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
            }
            catch(Exception e) {
                return;
            }
        }
        public void Update(CouponModel item)
        {

            try {
                using (IDbConnection dbConnection = GetConnection())
                {
                    string sQuery = "UPDATE Coupon SET "
                                    + " UserId = @UserId"
                                    + "Validity = @Validity "
                                    + "WHERE  InventoryId = @InventoryId";
                    dbConnection.Open();
                    dbConnection.Query(sQuery, item);
                }
            }
            catch(Exception e) {
                return;
            }
            
        }
 

    }
}