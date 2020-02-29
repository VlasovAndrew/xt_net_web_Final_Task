using Entities;
using Epam.FinalTask.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Epam.FinalTask.DAL
{
    public class SQLChannelDao : IChannelDao
    {
        private string _connectionString;

        public SQLChannelDao() {
            _connectionString = ConfigurationManager.ConnectionStrings["SocialHouseNetwork"].ConnectionString;
        }

        public Channel Add(Channel channel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateChannel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@channelID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@channelTitle", SqlDbType.NVarChar).Value = channel.Title;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int channelID = (int)command.Parameters["@channelID"].Value;
                    channel.ID = channelID;
                    return channel;
                }
            }
        }

        public Channel GetChannelById(int channelID)
        {
            Channel channel = new Channel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetChannel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@channelID", SqlDbType.Int).Value = channelID;
                    connection.Open();

                    var reader = command.ExecuteReader();
                    reader.Read();
                    channel.Title = (string)reader["Title"];
                }
            }
            IEnumerable<int> messages = GetMessages(channelID);
            foreach (var message in messages)
            {
                channel.Messages.Add(message);
            }
            return channel;
        }

        public Message SendMessage(int channelID, Message message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SendMessage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@channelID", SqlDbType.Int).Value = channelID;
                    command.Parameters.Add("@fromUserID", SqlDbType.Int).Value = message.UserID;
                    command.Parameters.Add("@messageText", SqlDbType.NVarChar).Value = message.Text;
                    command.Parameters.Add("@sendingTime", SqlDbType.DateTime).Value = message.SendingTime;
                    command.Parameters.Add("@messageID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();

                    int messageID = (int)command.Parameters["@messageID"].Value;
                    message.ID = messageID;
                }
            }
            return message;
        }
        public void DeleteMessage(int ChannelID, int MessageID)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Message> GetMessages(int channelID) {
            List<Message> messages = new List<Message>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetMessagesFromChannel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@channelID", SqlDbType.Int).Value = channelID;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        messages.Add(new Message()
                        {
                            ID = (int)reader["ID"],
                            UserID = (int)reader["FromUserID"],
                            Text = (string)reader["MessageText"],
                            SendingTime = (DateTime)reader["SendingTime"],
                        });
                    }
                }
            }
            return messages;
        }

        public IEnumerable<int> UserChannels(int userID)
        {
            List<int> channelIDs = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserChannels", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        channelIDs.Add((int)reader["ChannelID"]);
                    }
                }
            }
            return channelIDs;
        }
    }
}
