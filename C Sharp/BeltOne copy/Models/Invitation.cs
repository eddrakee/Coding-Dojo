using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class Invitation : BaseEntity
    {
        // This sets these params below as the key attribute
        [Key]
        public int InvitationId { get; set; }

        [ForeignKey("UserId")]
        public int PersonWhoAsked { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Friend> FriendsRequested { get; set; }
        public Invitation()
        {
            FriendsRequested = new List<Friend>();
        }
    }
}
