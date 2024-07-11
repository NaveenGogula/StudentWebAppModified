﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentWebApp.DataAccess.Data;

#nullable disable

namespace StudentWebApp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240625072243_ModifingDB")]
    partial class ModifingDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentWebApp.Models.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentBlock")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HOD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentBlock = "A",
                            DepartmentName = "Arts",
                            Description = "Arts department Students",
                            HOD = "Arts HOD"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentBlock = "B",
                            DepartmentName = "Science",
                            Description = "Science department Students",
                            HOD = "Science HOD"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentBlock = "C",
                            DepartmentName = "Computers",
                            Description = "Computers Science department Students",
                            HOD = "Computers HOD"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentBlock = "D",
                            DepartmentName = "Aeronautical",
                            Description = "Aeronautical department Students",
                            HOD = "Aeronautical HOD"
                        },
                        new
                        {
                            DepartmentId = 5,
                            DepartmentBlock = "E",
                            DepartmentName = "DataScience",
                            Description = "DataScience department Students",
                            HOD = "DataScience HOD"
                        });
                });

            modelBuilder.Entity("StudentWebApp.Models.Models.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Subscribed")
                        .HasColumnType("bit");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
