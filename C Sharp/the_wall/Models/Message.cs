using System;
using System.ComponentModel.DataAnnotations;
namespace the_wall.Models
{
    public class Message : BaseEntity
    {
        [Key]
        public long MessageId { get; set; }
 
        [Required]
        [MinLength(5)]
        public string MessageContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int User_Id { get; set; }
    }
}