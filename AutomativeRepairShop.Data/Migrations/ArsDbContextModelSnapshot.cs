﻿// <auto-generated />
using System;
using AutomativeRepairShop.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutomativeRepairShop.Data.Migrations
{
    [DbContext(typeof(ArsDbContext))]
    partial class ArsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentDate = new DateTime(2022, 2, 10, 18, 25, 33, 622, DateTimeKind.Local).AddTicks(4833),
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(704),
                            CustomerId = 1,
                            VehicleId = 1,
                            isApproved = false
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(1069),
                            CustomerId = 2,
                            VehicleId = 2,
                            isApproved = true
                        },
                        new
                        {
                            Id = 3,
                            AppointmentDate = new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(1073),
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(1075),
                            CustomerId = 2,
                            VehicleId = 3,
                            isApproved = true
                        });
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1236),
                            Email = "mulayimsert@gmail.com",
                            Name = "Mülayim",
                            PhoneNumber = "12345",
                            Surname = "Sert"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1243),
                            Email = "keanureeves@gmail.com",
                            Name = "Keanu",
                            PhoneNumber = "12345",
                            Surname = "Reeves"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1244),
                            Email = "donaldtrump@gmail.com",
                            Name = "Donald",
                            PhoneNumber = "12345",
                            Surname = "Trump"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1246),
                            Email = "testerenecmi@gmail.com",
                            Name = "Testere",
                            PhoneNumber = "12345",
                            Surname = "Necmi"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1247),
                            Email = "bugsbunny@gmail.com",
                            Name = "Bugs",
                            PhoneNumber = "12345",
                            Surname = "Bunny"
                        });
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Audi",
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4310),
                            CustomerId = 1,
                            LicensePlate = "34 ABC 123",
                            Model = "A3 Sedan",
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Fiat",
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4318),
                            CustomerId = 2,
                            LicensePlate = "34 DSA 123",
                            Model = "Egea",
                            Year = 2018
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Honda",
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4320),
                            CustomerId = 2,
                            LicensePlate = "34 FSD 123",
                            Model = "City",
                            Year = 2017
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Mercedes",
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4322),
                            CustomerId = 3,
                            LicensePlate = "34 HDS 123",
                            Model = "A Serisi",
                            Year = 2021
                        });
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("WorkOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 2,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(6121)
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 3,
                            CreateDate = new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(6128)
                        });
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Appointment", b =>
                {
                    b.HasOne("AutomativeRepairShop.Core.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AutomativeRepairShop.Core.Models.Vehicle", "Vehicle")
                        .WithMany("Appointments")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Vehicle", b =>
                {
                    b.HasOne("AutomativeRepairShop.Core.Models.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.WorkOrder", b =>
                {
                    b.HasOne("AutomativeRepairShop.Core.Models.Appointment", "Appointment")
                        .WithMany("WorkOrders")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Appointment", b =>
                {
                    b.Navigation("WorkOrders");
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Customer", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("AutomativeRepairShop.Core.Models.Vehicle", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
