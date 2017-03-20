using System;
using System.ComponentModel.DataAnnotations;
namespace the_wall.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public long CommentId { get; set; }
 
        [Required]
        [MinLength(5)]
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Message_Id { get; set; }
        public int User_Id { get; set; }

    }
}