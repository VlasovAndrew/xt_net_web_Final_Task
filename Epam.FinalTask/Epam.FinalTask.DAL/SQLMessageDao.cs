using Epam.FinalTask.Entities;
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
    public class SQLMessageDao : IMessageDao
    {
        private string _connectionString = ConfigurationManager
            .ConnectionStrings["SocialHouseNetwork"]
            .ConnectionString;
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Message Edit(Message message)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            Message message;
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand("GetMessageByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@messageID", System.Data.SqlDbType.Int).Value = id;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    reader.Read();
                    message = new Message()
                    {
                        ID = id,
                        ChannelID = (int)reader["ChannelID"],
                        UserID = (int)reader["FromUserID"],
                        Text = (string)reader["MessageText"],
                        SendingTime = (DateTime)reader["SendingTime"],
                    };
                }
            }
            return message;
        }
    }
}
