using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // This inverse look up will let us "look" backwards. Without this, you may get a "Unable to determine the relationship represented" error
        [InverseProperty("MessageAuthor")]
        public List<Message> MessagesSent { get; set; }

        [InverseProperty("MessageRecipient")]
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

// POSGRESS COMMANDS
// dotnet ef migrations remove

// TO MAKE MIGRATIONS DO THESE TWO COMMANDS
// dotnet ef migrations add NAMEMIGRATION
// dotnet ef database update