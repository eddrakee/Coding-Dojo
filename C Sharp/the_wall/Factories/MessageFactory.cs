using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using the_wall.Models;

namespace the_wall.Factory
{
    public class MessageFactory : IFactory<Message>
    {
        private string connectionString;
        public MessageFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=the_wall;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        public void AddMessage(Message item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO messages (MessageContent, CreatedAt, UpdatedAt) VALUES (@MessageContent, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Message> AllMessages()
        {
            using (IDbConnection dbConnection = Connection)
            {
                // string query = $"SELECT * FROM Messages JOIN Users ON Messages.User_Id=users.UserId";
                dbConnection.Open();
                return dbConnection.Query<Message>($"SELECT * FROM Messages JOIN Users ON Messages.User_Id=users.UserId");
                
            }

        }
    }
}
