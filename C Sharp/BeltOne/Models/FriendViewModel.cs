using System;
using System.ComponentModel.DataAnnotations;
namespace UserDash.Models
{
    public class FriendValidation : Friend
    {
        public new int InviteSentFromId { get; set; }
        public new int InviteReceivedId { get; set; }

        // This will convert UserValidation object into a User object
        public Friend ToFriend()
        {
           Friend NewFriend = new Friend
           {
                InviteSentFromId = this.InviteSentFromId,
                InviteReceivedId = this.InviteReceivedId

           };
           return NewFriend;
        }
    }
}