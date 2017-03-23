using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class Message : BaseEntity
    {
        // This sets these params below as the key attribute
        [Key]
        public int MessageId { get; set; }

        // This is who wrote the message
        [ForeignKey("UserId")]
        public int MessageAuthorId { get; set; }
        public User MessageAuthor { get; set; }

        // This is who received the message
        // We want to save two users so we can show their names on the user's profile wall
        [ForeignKey("UserId")]
        public int MessageRecipientId { get; set; }
        public User MessageRecipient { get; set; }

        public string MessageContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // These are comments associated to the message (in list form)
        public List<Comment> Comments { get; set; }
        public Message()
        {
            Comments = new List<Comment>();
        }
    }
}
