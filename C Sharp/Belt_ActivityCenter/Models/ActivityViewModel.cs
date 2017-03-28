using System;
using System.ComponentModel.DataAnnotations;
namespace UserDash.Models
{
    public class ActivityValidation : Activity
    {
        [Required]
        [MinLength(2)]
        public new string ActivityName { get; set; }

        [Required]
        [MinLength(10)]
        public new string ActivityDescription { get; set; }

        public new int ActivityCreatorId { get; set; }
        public new int ActivityJoinerId { get; set; }

        // This will convert UserValidation object into a User object
        public Activity ToActivity()
        {
            Activity NewActivity = new Activity
            {
                ActivityName = this.ActivityName,
                ActivityDescription = this.ActivityDescription,
                ActivityCreatorId = this.ActivityCreatorId,
                ActivityJoinerId = this.ActivityJoinerId

            };
            return NewActivity;
        }
    }
}