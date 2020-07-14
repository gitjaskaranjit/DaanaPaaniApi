﻿// <auto-generated />
using System;
using DaanaPaaniApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace DaanaPaaniApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DaanaPaaniApi.Entities.Address", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("AddressType")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNo")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("driverId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("driverId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<int>("DiscountValue")
                        .HasColumnType("int");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DriverEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LinceseExp")
                        .HasColumnType("datetime2");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.DriverAddress", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNo")
                        .HasColumnType("int");

                    b.HasKey("DriverId");

                    b.ToTable("DriverAddresses");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemPrice")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Location", b =>
                {
                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<Point>("LocationPoints")
                        .HasColumnType("Geometry")
                        .HasAnnotation("Sqlite:Srid", 4326);

                    b.Property<string>("formatted_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placeId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DiscountId")
                        .IsUnique()
                        .HasFilter("[DiscountId] IS NOT NULL");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderTempleteId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderTempleteId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.OrderTemplete", b =>
                {
                    b.Property<int>("OrderTempleteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<string>("OrderTempleteDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderTempleteId");

                    b.HasIndex("DiscountId")
                        .IsUnique()
                        .HasFilter("[DiscountId] IS NOT NULL");

                    b.ToTable("OrderTempletes");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Address", b =>
                {
                    b.HasOne("DaanaPaaniApi.Entities.Customer", "Customer")
                        .WithOne("Address")
                        .HasForeignKey("DaanaPaaniApi.Entities.Address", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Customer", b =>
                {
                    b.HasOne("DaanaPaaniApi.Entities.Driver", "driver")
                        .WithMany("customers")
                        .HasForeignKey("driverId");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.DriverAddress", b =>
                {
                    b.HasOne("DaanaPaaniApi.Entities.Driver", "driver")
                        .WithOne("driverAddress")
                        .HasForeignKey("DaanaPaaniApi.Entities.DriverAddress", "DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Location", b =>
                {
                    b.HasOne("DaanaPaaniApi.Entities.Customer", "customer")
                        .WithOne("locationInfo")
                        .HasForeignKey("DaanaPaaniApi.Entities.Location", "customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.Order", b =>
                {
                    b.HasOne("DaanaPaaniApi.Entities.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaanaPaaniApi.Entities.Discount", "Discount")
                        .WithOne("Order")
                        .HasForeignKey("DaanaPaaniApi.Entities.Order", "DiscountId");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.OrderItem", b =>
                {
                    b.HasOne("DaanaPaaniApi.Entities.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaanaPaaniApi.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("DaanaPaaniApi.Entities.OrderTemplete", "OrderTemplete")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderTempleteId");
                });

            modelBuilder.Entity("DaanaPaaniApi.Entities.OrderTemplete", b =>
                {
                    b.HasOne("DaanaPaaniApi.Entities.Discount", "Discount")
                        .WithOne("OrderTempletes")
                        .HasForeignKey("DaanaPaaniApi.Entities.OrderTemplete", "DiscountId");
                });
#pragma warning restore 612, 618
        }
    }
}
