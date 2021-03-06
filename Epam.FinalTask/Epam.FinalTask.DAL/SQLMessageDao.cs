﻿using Epam.FinalTask.Entities;
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
        private string _connectionString; 

        public SQLMessageDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SocialHouseNetwork"].ConnectionString;
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                using (SqlCommand command = new SqlCommand("DeleteMessage", connection)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@messageID", System.Data.SqlDbType.Int).Value = id;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(Message message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                using (SqlCommand command = new SqlCommand("UpdateMessageText", connection)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@messageID", System.Data.SqlDbType.Int).Value = message.ID;
                    command.Parameters.Add("@text", System.Data.SqlDbType.NVarChar).Value = message.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Message GetById(int id)
        {
            Message message;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetMessageByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@messageID", System.Data.SqlDbType.Int).Value = id;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (!reader.Read()) 
                    {
                        throw new ArgumentException($"Invalid message id = {id}", "id");
                    }
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
