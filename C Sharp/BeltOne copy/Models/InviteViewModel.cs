using System;
using System.ComponentModel.DataAnnotations;
namespace UserDash.Models
{
    public class InvitationValidation : Invitation
    {
        public new int PersonWhoAskedId { get; set; }
        // public new int InvitationRecipientId { get; set; }

        // This will convert UserValidation object into a User object
        public Invitation ToInvitation()
        {
           Invitation NewInvitation = new Invitation
           {
                PersonWhoAsked = this.PersonWhoAskedId,

           };
           return NewInvitation;
        }
    }
}