using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UserDash.Models;

namespace BeltOne.Migrations
{
    [DbContext(typeof(BaseContext))]
    partial class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("UserDash.Models.Friend", b =>
                {
                    b.Property<int>("FriendId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssociatedFriend");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("InvitationId");

                    b.Property<int>("InvitationSentFrom");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserId");

                    b.HasKey("FriendId");

                    b.HasIndex("InvitationId");

                    b.HasIndex("UserId");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("UserDash.Models.Invitation", b =>
                {
                    b.Property<int>("InvitationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("PersonWhoAsked");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserId");

                    b.Property<int?>("UserId1");

                    b.HasKey("InvitationId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Invitation");
                });

            modelBuilder.Entity("UserDash.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserDash.Models.Friend", b =>
                {
                    b.HasOne("UserDash.Models.Invitation")
                        .WithMany("FriendsRequested")
                        .HasForeignKey("InvitationId");

                    b.HasOne("UserDash.Models.User")
                        .WithMany("FriendList")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UserDash.Models.Invitation", b =>
                {
                    b.HasOne("UserDash.Models.User")
                        .WithMany("InvitationsReceived")
                        .HasForeignKey("UserId");

                    b.HasOne("UserDash.Models.User")
                        .WithMany("InvitationsSent")
                        .HasForeignKey("UserId1");
                });
        }
    }
}
