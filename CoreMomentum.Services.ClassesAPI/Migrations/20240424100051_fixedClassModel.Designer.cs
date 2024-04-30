﻿// <auto-generated />
using System;
using CoreMomentum.Services.ClassesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreMomentum.Services.ClassesAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240424100051_fixedClassModel")]
    partial class fixedClassModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreMomentum.Services.ClassesAPI.Models.ClassFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClassFeedback");
                });

            modelBuilder.Entity("CoreMomentum.Services.ClassesAPI.Models.ClassWeekday", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Hours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClassWeekday");
                });

            modelBuilder.Entity("CoreMomentum.Services.ClassesAPI.Models.Classes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassesCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CycleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassesCode")
                        .IsUnique();

                    b.ToTable("Classess");
                });

            modelBuilder.Entity("CoreMomentum.Services.ClassesAPI.Models.Weekday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Weekday");
                });

            modelBuilder.Entity("CoreMomentum.Services.ClassesAPI.Models.ClassWeekday", b =>
                {
                    b.HasOne("CoreMomentum.Services.ClassesAPI.Models.Classes", "Classes")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreMomentum.Services.ClassesAPI.Models.Weekday", "Weekday")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Weekday");
                });
#pragma warning restore 612, 618
        }
    }
}
