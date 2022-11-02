﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlannabelleClassLibrary.Data;

namespace PlannabelleClassLibrary.Migrations
{
    [DbContext(typeof(PlannabelleDbContext))]
    [Migration("20221008125356_moved_fields_to_enrollment")]
    partial class moved_fields_to_enrollment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlannabelleClassLibrary.Models.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassHoursPerWeek")
                        .HasColumnType("int");

                    b.Property<int>("SelfStudyHoursPerWeek")
                        .HasColumnType("int");

                    b.Property<double>("SelfStudyHoursRemaingForWeek")
                        .HasColumnType("float");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("moduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("UserId");

                    b.HasIndex("moduleId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("PlannabelleClassLibrary.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("PlannabelleClassLibrary.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("PlannabelleClassLibrary.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PlannabelleClassLibrary.Models.Enrollment", b =>
                {
                    b.HasOne("PlannabelleClassLibrary.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.HasOne("PlannabelleClassLibrary.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("PlannabelleClassLibrary.Models.Module", "module")
                        .WithMany()
                        .HasForeignKey("moduleId");
                });
#pragma warning restore 612, 618
        }
    }
}
