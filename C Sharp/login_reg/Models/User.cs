using System.ComponentModel.DataAnnotations;

    namespace login_reg.Models{
        public class User{
            [Required]
            [MinLengthAttribute(2)]
            public string FirstName { get; set;}

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
        }
    }