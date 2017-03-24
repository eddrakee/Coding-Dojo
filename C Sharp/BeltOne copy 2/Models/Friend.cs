using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class Friend : BaseEntity
    {
        [Key]
        public int FriendId { get; set; }

        [ForeignKey("UserId")]
        public int InviteSentFromId { get; set; }
        public User InviteSentFrom { get; set; }

        [ForeignKey("UserId")]
        public int InviteReceivedId { get; set; }
        public User InviteReceived { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}
