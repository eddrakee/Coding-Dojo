using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public abstract class BaseEntity { }
    public class User : BaseEntity
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLengthAttribute(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLengthAttribute(5)]
        [DataTypeAttribute(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [CompareAttribute("Password", ErrorMessage = "Your passwords do not match!")]
        public string PasswordConfirmation { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}