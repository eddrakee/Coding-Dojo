using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UserDash.Models;

namespace User_Dash.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20170322223651_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("UserDash.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssociatedMessageId");

                    b.Property<int>("CommentAuthorId");

                    b.Property<string>("CommentContent");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("CommentId");

                    b.HasIndex("AssociatedMessageId");

                    b.HasIndex("CommentAuthorId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("UserDash.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MessageAuthorId");

                    b.Property<string>("MessageContent");

                    b.Property<int>("MessageRecipientId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("MessageId");

                    b.HasIndex("MessageAuthorId");

                    b.HasIndex("MessageRecipientId");

                    b.ToTable("Message");
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

                    b.Property<int>("UserLevel");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserDash.Models.Comment", b =>
                {
                    b.HasOne("UserDash.Models.Message", "AssociatedMessage")
                        .WithMany("Comments")
                        .HasForeignKey("AssociatedMessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserDash.Models.User", "CommentAuthor")
                        .WithMany("CommentsSent")
                        .HasForeignKey("CommentAuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserDash.Models.Message", b =>
                {
                    b.HasOne("UserDash.Models.User", "MessageAuthor")
                        .WithMany("MessagesSent")
                        .HasForeignKey("MessageAuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserDash.Models.User", "MessageRecipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("MessageRecipientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
