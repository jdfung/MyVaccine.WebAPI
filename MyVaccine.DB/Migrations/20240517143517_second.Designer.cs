﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyVaccine.DB;

#nullable disable

namespace MyVaccine.DB.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240517143517_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyVaccine.DB.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("adminId"));

                    b.Property<string>("adminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("adminId");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("MyVaccine.DB.Applicants", b =>
                {
                    b.Property<int>("applicant_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("applicant_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("firstDose")
                        .HasColumnType("bit");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("secondDose")
                        .HasColumnType("bit");

                    b.HasKey("applicant_id");

                    b.ToTable("applicants");
                });

            modelBuilder.Entity("MyVaccine.DB.Appointment", b =>
                {
                    b.Property<int>("appointment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("appointment_id"));

                    b.Property<DateTime?>("firstDoseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("secondDoseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("vaccCenter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vaccChoice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("appointment_id");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("MyVaccine.DB.VaccCentre", b =>
                {
                    b.Property<int>("centreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("centreId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("centreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distrct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("centreId");

                    b.ToTable("vaccCentres");
                });
#pragma warning restore 612, 618
        }
    }
}
