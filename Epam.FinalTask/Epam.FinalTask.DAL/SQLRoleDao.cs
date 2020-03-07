using Epam.FinalTask.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.DAL
{
    public class SQLRoleDao : IRoleDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SocialHouseNetwork"].ConnectionString;

        public void AddRoleToAccount(string login, string role)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                using (SqlCommand command = new SqlCommand("AddRoleToAccount", connection)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@login", System.Data.SqlDbType.NVarChar).Value = login;
                    command.Parameters.Add("@role", System.Data.SqlDbType.NVarChar).Value = role;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<string> GetAllRoles(string login)
        {
            List<string> roles = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                using (SqlCommand command = new SqlCommand("GetRolesByLogin", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@login", System.Data.SqlDbType.NVarChar).Value = login;
                    connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read()) {
                        roles.Add((string)reader["RoleName"]);
                    }
                }
            }
            return roles;
        }

        public void RemoveRoleFromAccount(string login, string role)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("RemoveRoleFromAccount", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@login", System.Data.SqlDbType.NVarChar).Value = login;
                    command.Parameters.Add("@role", System.Data.SqlDbType.NVarChar).Value = role;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
