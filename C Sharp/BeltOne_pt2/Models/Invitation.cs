using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class Invite : BaseEntity
    {
        [Key]
        public int InviteId { get; set; }

        [ForeignKey("UserId")]
        // This is who I sent an invite to
        public int InviteSentFromId { get; set; }
        public User InviteSentFrom { get; set; }

        [ForeignKey("UserId")]
        // Who you received an invite from
        public int InviteReceivedId { get; set; }
        public User InviteReceived { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Accepted { get; set; }
       
    }
}
