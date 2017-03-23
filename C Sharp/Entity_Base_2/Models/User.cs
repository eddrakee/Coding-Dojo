using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserDash.Models
{
    public class User : BaseEntity
    {
        // This sets these params below as the key attribute
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int UserLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesReceived { get; set; }
        public List<Comment> CommentsSent { get; set; }
        public User()
         {
            MessagesSent = new List<Message>();
            MessagesReceived = new List<Message>();
            CommentsSent = new List<Comment>();
         }


        // For Many relationship
        // public List<Transaction> Transactions { get; set; }

        // public User()
        // {
        //     Transactions = new List<Transaction>();
        // }

    }
}
