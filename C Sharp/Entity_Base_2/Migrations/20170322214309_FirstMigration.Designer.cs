using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UserDash.Models;

namespace User_Dash.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20170322214309_FirstMigration")]
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

                    b.Property<int>("AssociatedMessage");

                    b.Property<int>("CommentAuthor");

                    b.Property<string>("CommentContent");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("MessageId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("UserDash.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MessageAuthor");

                    b.Property<string>("MessageContent");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserId");

                    b.Property<int?>("UserId1");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

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
                    b.HasOne("UserDash.Models.Message")
                        .WithMany("CommentForMessage")
                        .HasForeignKey("MessageId");

                    b.HasOne("UserDash.Models.User")
                        .WithMany("CommentsSent")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UserDash.Models.Message", b =>
                {
                    b.HasOne("UserDash.Models.User")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("UserId");

                    b.HasOne("UserDash.Models.User")
                        .WithMany("MessagesSent")
                        .HasForeignKey("UserId1");
                });
        }
    }
}
