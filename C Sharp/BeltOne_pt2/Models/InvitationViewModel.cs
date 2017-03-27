using System;
using System.ComponentModel.DataAnnotations;
namespace UserDash.Models
{
    public class InviteValidation : Invite
    {
        public new int InviteSentFromId { get; set; }
        public new int InviteReceivedId { get; set; }

        // This will convert UserValidation object into a User object
        public Invite ToInvite()
        {
           Invite NewInvite = new Invite
           {
                InviteSentFromId = this.InviteSentFromId,
                InviteReceivedId = this.InviteReceivedId

           };
           return NewInvite;
        }
    }
}