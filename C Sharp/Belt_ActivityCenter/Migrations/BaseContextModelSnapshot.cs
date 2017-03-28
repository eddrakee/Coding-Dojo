using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UserDash.Models;

namespace Belt_ActivityCenter.Migrations
{
    [DbContext(typeof(BaseContext))]
    partial class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("UserDash.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityCreatorId");

                    b.Property<DateTime>("ActivityDate");

                    b.Property<string>("ActivityDescription");

                    b.Property<int>("ActivityDuration");

                    b.Property<int>("ActivityJoinerId");

                    b.Property<string>("ActivityName");

                    b.Property<DateTime>("ActivityTime");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ActivityId");

                    b.HasIndex("ActivityCreatorId");

                    b.HasIndex("ActivityJoinerId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("UserDash.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserDash.Models.Activity", b =>
                {
                    b.HasOne("UserDash.Models.User", "ActivityCreator")
                        .WithMany("CreatorList")
                        .HasForeignKey("ActivityCreatorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserDash.Models.User", "ActivityJoiner")
                        .WithMany("JoinerList")
                        .HasForeignKey("ActivityJoinerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
