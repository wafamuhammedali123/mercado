using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using mercado.Interfaces;
using mercado.Model;

namespace mercado.Repository
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;
        public UserRepository()
        {
            connectionString = @"Server=localhost;Database=Market;Trusted_Connection=true";
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public IEnumerable<UserModel> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<UserModel>("SELECT * FROM [User]");
            }
        }
        public void Add(UserModel item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "INSERT INTO [User] (UserName,Password)"
                                 + " VALUES(@UserName,@Password)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);

            }
        }
        public void Update(UserModel item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "UPDATE [User] SET "
                                  + " Password = @Password "
                                  + "WHERE UserId = @UserId";
                dbConnection.Open();
                dbConnection.Query(sQuery, item);
            }
        }

        public UserModel Login(UserModel item)
        {
            try
            {
                using (IDbConnection dbConnection = GetConnection())
                {
                    string sQuery = @"
                    SELECT * FROM [User] WHERE UserName=@UserName AND
                    Password=@Password ";
                    dbConnection.Open();
                    var users = dbConnection.Query<UserModel>(sQuery, item);
                    return users.FirstOrDefault();
                }
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}