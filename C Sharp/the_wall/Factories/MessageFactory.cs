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
                string query = "INSERT INTO messages (MessageContent, CreatedAt, UpdatedAt, User_Id) VALUES (@MessageContent, NOW(), NOW(), @User_Id)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable <object> AllMessages()
        {
            using (IDbConnection dbConnection = Connection)
            {
                // string query = $"SELECT * FROM Messages JOIN Users ON Messages.User_Id=users.UserId";
                dbConnection.Open();
                return dbConnection.Query<object>($"SELECT * FROM Messages JOIN Users ON Messages.User_Id=users.UserId");
                // Need to make these ordered by earliest on top
                
            }

        }
    }
}
