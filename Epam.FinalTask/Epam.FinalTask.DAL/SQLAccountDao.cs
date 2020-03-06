using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Epam.FinalTask.DAL
{
    public class SQLAccountDao : IAccountDao
    {
        private string _connectionString;

        public SQLAccountDao() {
            _connectionString = ConfigurationManager.ConnectionStrings["SocialHouseNetwork"].ConnectionString;
        }

        public bool AccountExists(string login)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("AcoountExists", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
                    command.Parameters.Add("@exits", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();
                    return (bool)command.Parameters["@exits"].Value;
                }
            }
        }

        public Account Add(Account account)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddAccount", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@login", SqlDbType.NVarChar).Value = account.Login;
                    command.Parameters.Add("@password", SqlDbType.VarBinary).Value = account.Password;
                    if (account.UserID != 0)
                    {
                        command.Parameters.Add("@userID", SqlDbType.Int).Value = account.UserID;
                    }
                    command.Parameters.Add("@accountID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();
                    account.ID = (int)command.Parameters["@accountID"].Value;
                }    
            }
            return account;
        }

        public void AttachUserToAccount(string login, int userID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("AttachUserToAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
                    command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Account GetAccountByLogin(string login)
        {
            Account account = new Account();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetAccountByLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    
                    reader.Read();
                    account.ID = (int)reader["ID"];
                    account.Login = login;
                    account.Password = (byte[])reader["Password"];
                    var userID = reader["UserID"];
                    if (userID is DBNull)
                    {
                        account.UserID = 0;
                    }
                    else {
                        account.UserID = (int)userID;
                    }
                }
            }
            return account;
        }

        public int GetUserIDByLogin(string login)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserIDByLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
                    command.Parameters.Add("@userID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();

                    var res = command.Parameters["@userID"].Value;
                    if (res is DBNull)
                    {
                        return 0;
                    }
                    else {
                        return (int)res;
                    }
                }
            }
        }
    }
}
