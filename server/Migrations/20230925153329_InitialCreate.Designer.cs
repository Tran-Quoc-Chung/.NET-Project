﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Data;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230925153329_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("server.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginalID")
                        .HasColumnType("int");

                    b.HasKey("BrandID");

                    b.HasIndex("OriginalID");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("server.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("TotalCart")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("UserID");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("server.Models.CartDetail", b =>
                {
                    b.Property<int>("CartDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartDetailID"));

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("CartDetailID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartDetail", (string)null);
                });

            modelBuilder.Entity("server.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProductID");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("server.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("server.Models.DialShape", b =>
                {
                    b.Property<int>("DialShapeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DialShapeID"));

                    b.Property<string>("DialShapeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DialShapeID");

                    b.ToTable("DialShape", (string)null);
                });

            modelBuilder.Entity("server.Models.DialSize", b =>
                {
                    b.Property<int>("DialSizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DialSizeID"));

                    b.Property<string>("DialSizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DialSizeID");

                    b.ToTable("DialSize", (string)null);
                });

            modelBuilder.Entity("server.Models.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderID"));

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender", (string)null);
                });

            modelBuilder.Entity("server.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusInvoiceID")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int>("TotalProduct")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("InvoiceID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StatusInvoiceID");

                    b.HasIndex("UserID");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("server.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("InvoiceDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceDetailID"));

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.HasKey("InvoiceDetailID");

                    b.HasIndex("InvoiceID");

                    b.ToTable("InvoiceDetail", (string)null);
                });

            modelBuilder.Entity("server.Models.Original", b =>
                {
                    b.Property<int>("OriginalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OriginalID"));

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OriginalID");

                    b.ToTable("Original", (string)null);
                });

            modelBuilder.Entity("server.Models.Permission", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionID"));

                    b.Property<string>("PermissionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionID");

                    b.ToTable("Permission", (string)null);
                });

            modelBuilder.Entity("server.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DialShapeID")
                        .HasColumnType("int");

                    b.Property<int>("DialSizeID")
                        .HasColumnType("int");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceDetailID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Sold")
                        .HasColumnType("int");

                    b.Property<int>("StrapMaterialID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.Property<double>("TotalRating")
                        .HasColumnType("float");

                    b.Property<int>("WaterResistanceID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("BrandID");

                    b.HasIndex("DialShapeID");

                    b.HasIndex("DialSizeID");

                    b.HasIndex("GenderID");

                    b.HasIndex("InvoiceDetailID");

                    b.HasIndex("StrapMaterialID");

                    b.HasIndex("TagID");

                    b.HasIndex("WaterResistanceID");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("server.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("server.Models.RoleToPermission", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.HasKey("RoleID", "PermissionID");

                    b.HasIndex("PermissionID");

                    b.ToTable("RoleToPermission", (string)null);
                });

            modelBuilder.Entity("server.Models.StatusActive", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusID"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("StatusActive", (string)null);
                });

            modelBuilder.Entity("server.Models.StatusInvoice", b =>
                {
                    b.Property<int>("StatusInvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusInvoiceID"));

                    b.Property<string>("StatusInvoiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusInvoiceID");

                    b.ToTable("StatusInvoice", (string)null);
                });

            modelBuilder.Entity("server.Models.StrapMaterial", b =>
                {
                    b.Property<int>("StrapMaterialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StrapMaterialID"));

                    b.Property<string>("StrapMaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StrapMaterialID");

                    b.ToTable("StrapMaterial", (string)null);
                });

            modelBuilder.Entity("server.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagID"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.ToTable("Tag", (string)null);
                });

            modelBuilder.Entity("server.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("StatusID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("server.Models.UserToRole", b =>
                {
                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("RoleID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserToRole", (string)null);
                });

            modelBuilder.Entity("server.Models.Voucher", b =>
                {
                    b.Property<string>("VoucherCode")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VoucherStatusID")
                        .HasColumnType("int");

                    b.HasKey("VoucherCode");

                    b.HasIndex("CreatedByUserID");

                    b.HasIndex("VoucherStatusID");

                    b.ToTable("Voucher", (string)null);
                });

            modelBuilder.Entity("server.Models.VoucherStatus", b =>
                {
                    b.Property<int>("VoucherStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoucherStatusID"));

                    b.Property<string>("VoucherStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoucherStatusID");

                    b.ToTable("VoucherStatus", (string)null);
                });

            modelBuilder.Entity("server.Models.WaterResistance", b =>
                {
                    b.Property<int>("WaterResistanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WaterResistanceID"));

                    b.Property<string>("WaterResistanceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WaterResistanceID");

                    b.ToTable("WaterResistance", (string)null);
                });

            modelBuilder.Entity("server.Models.Brand", b =>
                {
                    b.HasOne("server.Models.Original", "Original")
                        .WithMany()
                        .HasForeignKey("OriginalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Original");
                });

            modelBuilder.Entity("server.Models.Cart", b =>
                {
                    b.HasOne("server.Models.Customer", "Customerid")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.User", "Userid")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customerid");

                    b.Navigation("Userid");
                });

            modelBuilder.Entity("server.Models.CartDetail", b =>
                {
                    b.HasOne("server.Models.Cart", "Cartid")
                        .WithMany()
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartid");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("server.Models.Comment", b =>
                {
                    b.HasOne("server.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("server.Models.Invoice", b =>
                {
                    b.HasOne("server.Models.Customer", "Customerid")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.StatusInvoice", "StatusInvoice")
                        .WithMany()
                        .HasForeignKey("StatusInvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.User", "Userid")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customerid");

                    b.Navigation("StatusInvoice");

                    b.Navigation("Userid");
                });

            modelBuilder.Entity("server.Models.InvoiceDetail", b =>
                {
                    b.HasOne("server.Models.Invoice", "Invoiceid")
                        .WithMany()
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoiceid");
                });

            modelBuilder.Entity("server.Models.Product", b =>
                {
                    b.HasOne("server.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.DialShape", "DialShape")
                        .WithMany()
                        .HasForeignKey("DialShapeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.DialSize", "DialSize")
                        .WithMany()
                        .HasForeignKey("DialSizeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.InvoiceDetail", null)
                        .WithMany("Products")
                        .HasForeignKey("InvoiceDetailID");

                    b.HasOne("server.Models.StrapMaterial", "StrapMaterial")
                        .WithMany()
                        .HasForeignKey("StrapMaterialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.WaterResistance", "WaterResistance")
                        .WithMany()
                        .HasForeignKey("WaterResistanceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("DialShape");

                    b.Navigation("DialSize");

                    b.Navigation("Gender");

                    b.Navigation("StrapMaterial");

                    b.Navigation("Tag");

                    b.Navigation("WaterResistance");
                });

            modelBuilder.Entity("server.Models.RoleToPermission", b =>
                {
                    b.HasOne("server.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("server.Models.User", b =>
                {
                    b.HasOne("server.Models.StatusActive", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("server.Models.UserToRole", b =>
                {
                    b.HasOne("server.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.Models.Voucher", b =>
                {
                    b.HasOne("server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.VoucherStatus", "VoucherStatus")
                        .WithMany()
                        .HasForeignKey("VoucherStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("VoucherStatus");
                });

            modelBuilder.Entity("server.Models.InvoiceDetail", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
