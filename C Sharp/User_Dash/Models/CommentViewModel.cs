using System;
using System.ComponentModel.DataAnnotations;
namespace UserDash.Models
{
    public class CommentValidation : Comment
    {
        [Required]
        [MinLength(8)]
        public new string CommentContent { get; set; }

        public new int CommentAuthorId { get; set; }

        public new int AssociatedMessageId { get; set; }
        // this is something new that we added in and doesn't exist in our Comment Table. Therefore it doesn't become part of the ToComment Method
        // But it is saved in this object so we can use it later
        public int ProfileId { get; set; }

        // This will convert UserValidation object into a User object
        public Comment ToComment()
        {
           Comment NewComment = new Comment
           {
                CommentContent = this.CommentContent,
                CommentAuthorId = this.CommentAuthorId,
                AssociatedMessageId = this.AssociatedMessageId

           };
           return NewComment;
        }
    }
}