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
    public class SQLUserDao : IUserDao
    {
        private string _connectionString;
        public SQLUserDao()
        {
            _connectionString = ConfigurationManager
                              .ConnectionStrings["SocialHouseNetwork"].ConnectionString;
        
        }

        public User Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user.Name;
                    command.Parameters.Add("@Lastname", SqlDbType.NVarChar).Value = user.Surname;
                    command.Parameters.Add("@Birthday", SqlDbType.Date).Value = user.Birthday;
                    command.Parameters.Add("@City", SqlDbType.NVarChar).Value = user.City;
                    command.Parameters.Add("@Street", SqlDbType.NVarChar).Value = user.Street;
                    command.Parameters.Add("@HouseNumber", SqlDbType.NVarChar).Value = user.HouseNumber;
                    command.Parameters.Add("@ApartmentNumber", SqlDbType.NVarChar).Value = user.ApartmentNumber;
                    command.Parameters.Add("@ProfilePhoto", SqlDbType.NVarChar).Value = user.ImagePath;
                    command.Parameters.Add("@userID", SqlDbType.Int).Direction = ParameterDirection.Output;
            
                    connection.Open();
                    command.ExecuteNonQuery();
                    
                    int userID = (int)command.Parameters["@userID"].Value;
                    user.ID = userID;
                    return user;
                }
            }
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            List<int> userIDs = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetAllUsersID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userIDs.Add((int)reader["ID"]);
                    }
                }
            }
            foreach (var userID in userIDs)
            {
                users.Add(GetById(userID));
            }
            return users;
        }

        public User GetById(int id)
        {
            User user;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@userID", SqlDbType.Int).Value = id;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    reader.Read();
                    
                    user = new User()
                    {
                        ID = id,
                        Name = (string)reader["Name"],
                        Surname = (string)reader["LastName"],
                        Birthday = (DateTime)reader["Birthday"],
                        City = (string)reader["City"],
                        Street = (string)reader["Street"],
                        HouseNumber = (string)reader["HouseNumber"],
                        ApartmentNumber = (int)reader["ApartmentNumber"],
                        ImagePath = reader["ProfilePhoto"] as string,
                    };
                }
            }
            IEnumerable<int> friends = GetUserFriends(id);
            foreach (var friendID in friends)
            {
                user.Friends.Add(friendID);
            }

            return user;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<int> GetUserFriends(int userID)
        {
            List<int> friendID = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserFriends", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        friendID.Add((int)reader["ToUserID"]);
                    }
                }
            }
            return friendID;
        }
    }
}
