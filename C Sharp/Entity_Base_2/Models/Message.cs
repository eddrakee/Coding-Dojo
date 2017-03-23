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

        [ForeignKey("UserId")]
        public int MessageAuthor { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Comment> CommentForMessage { get; set; }
        public Message()
        {
            CommentForMessage = new List<Comment>();
        }
    }
}
