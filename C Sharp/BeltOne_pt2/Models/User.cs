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
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [InverseProperty("InviteSentFrom")]
        public List<Invite> InviteInvitesSent { get; set; }

        [InverseProperty("InviteReceived")]
        public List<Invite> InviteInvitesReceived { get; set; }
        
        
        public User()
        {
            InviteInvitesSent = new List<Invite>();
            InviteInvitesReceived = new List<Invite>();
        }
    }
}
