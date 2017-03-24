using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<Invitation> InvitationsSent { get; set; }
        public List<Invitation> InvitationsReceived { get; set; }
        public List<Friend> FriendList { get; set; }
        public User()
         {
            InvitationsSent = new List<Invitation>();
            InvitationsReceived = new List<Invitation>();
            FriendList = new List<Friend>();
         }


        // For Many relationship
        // public List<Transaction> Transactions { get; set; }

        // public User()
        // {
        //     Transactions = new List<Transaction>();
        // }

    }
}
