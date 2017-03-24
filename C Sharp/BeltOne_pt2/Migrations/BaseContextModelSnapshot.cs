using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UserDash.Models;

namespace BeltOne_pt2.Migrations
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

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("InviteReceivedId");

                    b.Property<int>("InviteSentFromId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserId");

                    b.HasKey("FriendId");

                    b.HasIndex("InviteReceivedId");

                    b.HasIndex("InviteSentFromId");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");
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
                    b.HasOne("UserDash.Models.User", "InviteReceived")
                        .WithMany("FriendInvitesReceived")
                        .HasForeignKey("InviteReceivedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserDash.Models.User", "InviteSentFrom")
                        .WithMany("FriendInvitesSent")
                        .HasForeignKey("InviteSentFromId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserDash.Models.User")
                        .WithMany("FriendList")
                        .HasForeignKey("UserId");
                });
        }
    }
}
