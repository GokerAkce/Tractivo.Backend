﻿// <auto-generated />
using System;
using Backend.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.API.Migrations
{
    [DbContext(typeof(TractivoContext))]
    partial class TractivoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.API.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentRangeType")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ContractId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            ContractId = 1,
                            CustomerId = 1,
                            EndDate = new DateTime(2020, 5, 26, 0, 43, 0, 478, DateTimeKind.Local).AddTicks(4401),
                            Name = "Short Time Tenancy Contract",
                            PaymentRangeType = 0,
                            Price = 750.0,
                            StartDate = new DateTime(2020, 1, 26, 0, 43, 0, 477, DateTimeKind.Local).AddTicks(1304)
                        });
                });

            modelBuilder.Entity("Backend.API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "35 Carlberg Avenue",
                            City = "Oxford",
                            Country = "UK",
                            Email = "mpeel@localhost.com",
                            FirstName = "Mark",
                            LastName = "Peel",
                            Phone = "05555555555"
                        },
                        new
                        {
                            Id = 2,
                            Address = "25 Kebel Road",
                            City = "Oxford",
                            Country = "UK",
                            Email = "jcursy@localhost.com",
                            FirstName = "John",
                            LastName = "Cursy",
                            Phone = "05555555555"
                        });
                });

            modelBuilder.Entity("Backend.API.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MaturityDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceId = 1,
                            CustomerId = 1,
                            InvoiceNumber = "AAA000",
                            MaturityDate = new DateTime(2020, 2, 10, 0, 43, 0, 478, DateTimeKind.Local).AddTicks(8053),
                            Price = 350.0,
                            StartDate = new DateTime(2020, 1, 26, 0, 43, 0, 478, DateTimeKind.Local).AddTicks(8040)
                        });
                });

            modelBuilder.Entity("Backend.API.Models.Contract", b =>
                {
                    b.HasOne("Backend.API.Models.Customer", "Customer")
                        .WithMany("Contracts")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Backend.API.Models.Invoice", b =>
                {
                    b.HasOne("Backend.API.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
