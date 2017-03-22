using System;
using System.ComponentModel.DataAnnotations;
namespace UserDash.Models
{
    public class UserValidation : User
    {
        // Instead of using BaseEntity, I will be using the User obj constructor. 
        // Everything is set as "new" because it is overriding the definition in the User.cs

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public new string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public new string LastName { get; set; }
 
        [Required]
        [EmailAddress]
        public new string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public new string Password { get; set; }
 
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string ConfirmPassword { get; set; }

        // This will convert UserValidation object into a User object
        public User ToUser()
        {
           User NewUser = new User
           {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email.ToLower(),
                Password = this.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
           };
           return NewUser;
        }
    }
}