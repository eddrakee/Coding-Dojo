using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class Comment : BaseEntity
    {
        // This sets these params below as the key attribute
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("UserId")]
        public int CommentAuthorId { get; set; }
        public User CommentAuthor { get; set; }

        [ForeignKey("MessageId")]
        public int AssociatedMessageId { get; set; }
        public Message AssociatedMessage { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}
