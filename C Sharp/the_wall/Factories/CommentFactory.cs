using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using the_wall.Models;

namespace the_wall.Factory
{
    public class CommentFactory : IFactory<Message>
    {
        private string connectionString;
        public CommentFactory()
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
        public void AddComment(Comment item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO comments (CommentContent, CreatedAt, UpdatedAt, Message_Id, User_Id) VALUES (@CommentContent, NOW(), NOW(), @Message_Id, @User_Id)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
         public IEnumerable <object> AllComments()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<object>($"SELECT * FROM Comments JOIN Users ON Comments.User_Id=users.UserId");
                // Need to make these ordered by earliest on top
                
            }

        }

    }
}
