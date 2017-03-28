using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class User : BaseEntity
    {
        // This sets these params below as the key attribute
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // This inverse look up will let us "look" backwards. Without this, you may get a "Unable to determine the relationship represented" error
        [InverseProperty("ActivityCreator")]
        public List<Activity> CreatorList { get; set; }

        [InverseProperty("ActivityJoiner")]
        public List<Activity> JoinerList { get; set; }
    
        public User()
         {
            CreatorList = new List<Activity>();
            JoinerList = new List<Activity>();
         }
    }
}

// POSGRESS COMMANDS
// dotnet ef migrations remove

// TO MAKE MIGRATIONS DO THESE TWO COMMANDS
// dotnet ef migrations add NAMEMIGRATION
// dotnet ef database update