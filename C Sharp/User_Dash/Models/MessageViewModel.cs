using System;
using System.ComponentModel.DataAnnotations;
namespace UserDash.Models
{
    public class MessageValidation : Message
    {
        [Required]
        [MinLength(8)]
        public new string MessageContent { get; set; }

        public new int MessageAuthorId { get; set; }
        public new int MessageRecipientId { get; set; }

        // This will convert UserValidation object into a User object
        public Message ToMessage()
        {
           Message NewMessage = new Message
           {
                MessageContent = this.MessageContent,
                MessageAuthorId = this.MessageAuthorId,
                MessageRecipientId = this.MessageRecipientId

           };
           return NewMessage;
        }
    }
}