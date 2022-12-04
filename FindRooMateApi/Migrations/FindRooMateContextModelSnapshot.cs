﻿// <auto-generated />
using System;
using FindRooMateApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FindRooMateApi.Migrations
{
    [DbContext(typeof(FindRooMateContext))]
    partial class FindRooMateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FindRooMateApi.Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("StudentId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Dormitory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Dormitories");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("DormitoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DormitoryId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.RoomStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("StudentId");

                    b.ToTable("RoomStudent", (string)null);
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Application", b =>
                {
                    b.HasOne("FindRooMateApi.Entities.Announcement", "Announcement")
                        .WithMany("Applications")
                        .HasForeignKey("AnnouncementId")
                        .IsRequired()
                        .HasConstraintName("FK_Applications_Announcements");

                    b.HasOne("FindRooMateApi.Entities.Student", "Student")
                        .WithMany("Applications")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Applications_Students");

                    b.Navigation("Announcement");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Room", b =>
                {
                    b.HasOne("FindRooMateApi.Entities.Dormitory", "Dormitory")
                        .WithMany("Rooms")
                        .HasForeignKey("DormitoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Rooms_Dormitories");

                    b.Navigation("Dormitory");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.RoomStudent", b =>
                {
                    b.HasOne("FindRooMateApi.Entities.Room", "Room")
                        .WithMany("RoomStudents")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK_RoomStudent_Rooms");

                    b.HasOne("FindRooMateApi.Entities.Student", "Student")
                        .WithMany("RoomStudents")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_RoomStudent_Students");

                    b.Navigation("Room");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Announcement", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Dormitory", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Room", b =>
                {
                    b.Navigation("RoomStudents");
                });

            modelBuilder.Entity("FindRooMateApi.Entities.Student", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("RoomStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
