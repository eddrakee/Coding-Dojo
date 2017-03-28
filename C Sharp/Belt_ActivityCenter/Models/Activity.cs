using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDash.Models
{
    public class Activity : BaseEntity
    {
        // This sets these params below as the key attribute
        [Key]
        public int ActivityId { get; set; }

        // This is who created the Activity
        [ForeignKey("UserId")]
        public int ActivityCreatorId { get; set; }
        public User ActivityCreator { get; set; }

        // This is who joined the Activity
        // We want to save two users so we can show their names on the user's profile wall
        [ForeignKey("UserId")]
        public int ActivityJoinerId { get; set; }
        public User ActivityJoiner { get; set; }

        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public int ActivityDuration{ get; set; }
        public DateTime ActivityDate{ get; set; }
        public DateTime ActivityTime{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
