﻿// <auto-generated />
using System;
using DoMeAFavor.DataService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoMeAFavor.DataService.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoMeAFavor.DataService.Models.CompletedMission", b =>
                {
                    b.Property<int>("MissioinId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("CompleteTime");

                    b.Property<int>("Evaluation");

                    b.HasKey("MissioinId", "UserId");

                    b.ToTable("CompletedMissions");
                });

            modelBuilder.Entity("DoMeAFavor.DataService.Models.Mission", b =>
                {
                    b.Property<int>("MissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("Deadline");

                    b.Property<int>("Points");

                    b.Property<int>("PublisherId");

                    b.Property<DateTime>("ReleaseTime");

                    b.Property<string>("Type");

                    b.HasKey("MissionId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("DoMeAFavor.DataService.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<int>("Class");

                    b.Property<string>("Major");

                    b.Property<string>("Password");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("Points");

                    b.Property<string>("RealName");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}