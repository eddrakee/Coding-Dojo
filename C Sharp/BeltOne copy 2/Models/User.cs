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
        public List<Friend> FriendInvitesSent { get; set; }

        [InverseProperty("InviteReceived")]
        public List<Friend> FriendInvitesReceived { get; set; }
        
        public List<Friend> FriendList { get; set; }
        
        public User()
        {
            FriendInvitesSent = new List<Friend>();
            FriendInvitesReceived = new List<Friend>();
            FriendList = new List<Friend>();
        }
    }
}
