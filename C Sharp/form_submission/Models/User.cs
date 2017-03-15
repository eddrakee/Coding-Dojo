using System.ComponentModel.DataAnnotations;
using System.IO;

namespace form_submission.Models{
    public class User{
    
    // First Name Validation
    [Required]
    [MinLengthAttribute(4)]
    public string FirstName { get; set; }

    // Last Name Validation
    [Required]
    [MinLengthAttribute(4)]
    public string LastName { get; set; }

    // Age Validation
    [Required]
    // This is a range from 0 to max value
    [RangeAttribute(0, 200)]
    public int Age { get; set; }

    // Email Validation
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    // Password Validation
    [Required]
    [DataTypeAttribute(DataType.Password)]
    public string Password { get; set; }

    }
}