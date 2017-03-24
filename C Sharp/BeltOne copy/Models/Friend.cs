using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class Friend : BaseEntity
    {
        // This sets these params below as the key attribute
        [Key]
        public int FriendId { get; set; }

        [ForeignKey("UserId")]
        public int InvitationSentFrom { get; set; }

        [ForeignKey("InvitationId")]
        public int AssociatedFriend { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}
