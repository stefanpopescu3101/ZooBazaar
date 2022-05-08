using Class_Library.Object_Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library.Data_Access {
    public class MessageDb : DBMediator {
        public MessageDb() : base() { }

        public int AddNewMessage(Message m) {
            try {
                var sql = "insert into messages_zoo (Message, Date) values (@text, @date)";
                var cmd = new MySqlCommand(sql, this.connection);
                cmd.Parameters.AddWithValue("@text", m.MessageText);
                cmd.Parameters.AddWithValue("@date", m.MessageDate);                

                connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                return (int)id;
            } finally {
                connection.Close();
            }
        }

        public List<Message> GetAllMessages() {
            try {
                var sql = "select * from messages_zoo";
                var cmd = new MySqlCommand(sql, this.connection);

                connection.Open();
                var data = cmd.ExecuteReader();                
                List<Message> messages = new List<Message>();
                while (data.Read()) {
                    TimeSpan timePassedSinceMessage = DateTime.Now - data.GetDateTime(2);
                    TimeSpan week = new TimeSpan(7, 0, 0, 0);
                    if (timePassedSinceMessage < week) {
                        messages.Add(
                        new Message(
                            data.GetString(1),
                            data.GetDateTime(2)
                            )
                        );
                    }                    
                }
                return messages;
            } finally {
                connection.Close();
            }
        }
    }
}
