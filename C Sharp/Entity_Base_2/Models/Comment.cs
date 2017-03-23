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
        public int CommentAuthor { get; set; }

        [ForeignKey("MessageId")]
        public int AssociatedMessage { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}
