﻿// <auto-generated />
using System;
using DaanaPaaniApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DaanaPaaniApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("DaanaPaaniApi.Model.AddOn", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("AddOns");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Address", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetName")
                        .HasColumnType("TEXT");

                    b.Property<int>("StreetNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.HasIndex("AddressTypeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.AddressType", b =>
                {
                    b.Property<int>("AddressTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressTypeName")
                        .HasColumnType("TEXT");

                    b.HasKey("AddressTypeId");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fullname")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Discount", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscountTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscountValue")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("DiscountTypeId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.DiscountType", b =>
                {
                    b.Property<int>("DiscountTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscountTypeName")
                        .HasColumnType("TEXT");

                    b.HasKey("DiscountTypeId");

                    b.ToTable("DiscountTypes");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ItemPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.LocationInfo", b =>
                {
                    b.Property<int>("customerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("formatted_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("lat")
                        .HasColumnType("TEXT");

                    b.Property<string>("lng")
                        .HasColumnType("TEXT");

                    b.Property<string>("placeId")
                        .HasColumnType("TEXT");

                    b.HasKey("customerId");

                    b.ToTable("LocationInfos");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PackageId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("customerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("PackageId");

                    b.HasIndex("customerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PackageName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PackagePrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.PackageItem", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PackageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId", "PackageId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageItems");
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.AddOn", b =>
                {
                    b.HasOne("DaanaPaaniApi.Model.Item", "Item")
                        .WithMany("AddOns")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaanaPaaniApi.Model.Order", "Order")
                        .WithMany("AddOns")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Address", b =>
                {
                    b.HasOne("DaanaPaaniApi.Model.AddressType", "AddressType")
                        .WithMany("Addresses")
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaanaPaaniApi.Model.Customer", "Customer")
                        .WithOne("Address")
                        .HasForeignKey("DaanaPaaniApi.Model.Address", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Discount", b =>
                {
                    b.HasOne("DaanaPaaniApi.Model.DiscountType", "DiscountType")
                        .WithMany("Discounts")
                        .HasForeignKey("DiscountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaanaPaaniApi.Model.Order", "Order")
                        .WithOne("Discount")
                        .HasForeignKey("DaanaPaaniApi.Model.Discount", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.LocationInfo", b =>
                {
                    b.HasOne("DaanaPaaniApi.Model.Customer", "customer")
                        .WithOne("locationInfo")
                        .HasForeignKey("DaanaPaaniApi.Model.LocationInfo", "customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.Order", b =>
                {
                    b.HasOne("DaanaPaaniApi.Model.Package", "Package")
                        .WithMany("Orders")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaanaPaaniApi.Model.Customer", "customer")
                        .WithMany("Order")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaanaPaaniApi.Model.PackageItem", b =>
                {
                    b.HasOne("DaanaPaaniApi.Model.Item", "Item")
                        .WithMany("PackageItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaanaPaaniApi.Model.Package", "Package")
                        .WithMany("PackageItems")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
