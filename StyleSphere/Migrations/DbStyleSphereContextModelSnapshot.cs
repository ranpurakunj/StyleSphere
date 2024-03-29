﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StyleSphere.Models;

#nullable disable

namespace StyleSphere.Migrations
{
    [DbContext(typeof(DbStyleSphereContext))]
    partial class DbStyleSphereContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StyleSphere.Models.TblCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("ShowOnTop")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("tbl_Categories", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblColorMaster", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ColorID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ColorId");

                    b.ToTable("tbl_ColorMaster", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("CustomerId");

                    b.ToTable("tbl_Customer", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblFavorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FavoriteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoriteId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.HasKey("FavoriteId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("tbl_Favorites", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblOrderDatum", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("numeric(10, 2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("TrackingId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TrackingID");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("tbl_OrderData", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblOrderDetail", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailsId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(10, 2)");

                    b.Property<int>("ProductMappingId")
                        .HasColumnType("int")
                        .HasColumnName("ProductMappingID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric(10, 2)");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductMappingId");

                    b.ToTable("tbl_OrderDetail", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Image1")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Image2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Image3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("MfgDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(10, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("SubCategoryID");

                    b.Property<string>("ThumbnailImage")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("tbl_Product", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblProductMapping", b =>
                {
                    b.Property<int>("ProductMappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductMappingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductMappingId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<int>("ColorId")
                        .HasColumnType("int")
                        .HasColumnName("ColorID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("SizeId")
                        .HasColumnType("int")
                        .HasColumnName("SizeID");

                    b.HasKey("ProductMappingId");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("tbl_ProductMapping", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblRating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RatingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("tbl_Rating", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblSizeMaster", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SizeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<int>("Eusize")
                        .HasColumnType("int")
                        .HasColumnName("EUSize");

                    b.Property<int>("Ussize")
                        .HasColumnType("int")
                        .HasColumnName("USSize");

                    b.HasKey("SizeId");

                    b.ToTable("tbl_SizeMaster", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblSubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SubCategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("tbl_SubCategories", (string)null);
                });

            modelBuilder.Entity("StyleSphere.Models.TblFavorite", b =>
                {
                    b.HasOne("StyleSphere.Models.TblCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_Favorites_tbl_Customer");

                    b.HasOne("StyleSphere.Models.TblProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_Favorites_tbl_Product");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StyleSphere.Models.TblOrderDatum", b =>
                {
                    b.HasOne("StyleSphere.Models.TblCustomer", "Customer")
                        .WithMany("TblOrderData")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_OrderData_tbl_Customer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("StyleSphere.Models.TblOrderDetail", b =>
                {
                    b.HasOne("StyleSphere.Models.TblOrderDatum", "Order")
                        .WithMany("TblOrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_OrderDetail_tbl_OrderData");

                    b.HasOne("StyleSphere.Models.TblProductMapping", "ProductMapping")
                        .WithMany("TblOrderDetails")
                        .HasForeignKey("ProductMappingId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_OrderDetail_tbl_ProductMapping");

                    b.Navigation("Order");

                    b.Navigation("ProductMapping");
                });

            modelBuilder.Entity("StyleSphere.Models.TblProduct", b =>
                {
                    b.HasOne("StyleSphere.Models.TblCategory", "Category")
                        .WithMany("TblProducts")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_Product_tbl_Categories");

                    b.HasOne("StyleSphere.Models.TblSubCategory", "SubCategory")
                        .WithMany("TblProducts")
                        .HasForeignKey("SubCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_Product_tbl_SubCategories");

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("StyleSphere.Models.TblProductMapping", b =>
                {
                    b.HasOne("StyleSphere.Models.TblColorMaster", "Color")
                        .WithMany("TblProductMappings")
                        .HasForeignKey("ColorId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_ProductMapping_tbl_ColorMaster");

                    b.HasOne("StyleSphere.Models.TblProduct", "Product")
                        .WithMany("TblProductMappings")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_ProductMapping_tbl_Product");

                    b.HasOne("StyleSphere.Models.TblSizeMaster", "Size")
                        .WithMany("TblProductMappings")
                        .HasForeignKey("SizeId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_ProductMapping_tbl_SizeMaster");

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("StyleSphere.Models.TblRating", b =>
                {
                    b.HasOne("StyleSphere.Models.TblCustomer", "Customer")
                        .WithMany("TblRatings")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_Rating_tbl_Customer");

                    b.HasOne("StyleSphere.Models.TblProduct", "Product")
                        .WithMany("TblRatings")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_Rating_tbl_Product");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StyleSphere.Models.TblSubCategory", b =>
                {
                    b.HasOne("StyleSphere.Models.TblCategory", "Category")
                        .WithMany("TblSubCategories")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_tbl_SubCategories_tbl_Categories");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StyleSphere.Models.TblCategory", b =>
                {
                    b.Navigation("TblProducts");

                    b.Navigation("TblSubCategories");
                });

            modelBuilder.Entity("StyleSphere.Models.TblColorMaster", b =>
                {
                    b.Navigation("TblProductMappings");
                });

            modelBuilder.Entity("StyleSphere.Models.TblCustomer", b =>
                {
                    b.Navigation("TblOrderData");

                    b.Navigation("TblRatings");
                });

            modelBuilder.Entity("StyleSphere.Models.TblOrderDatum", b =>
                {
                    b.Navigation("TblOrderDetails");
                });

            modelBuilder.Entity("StyleSphere.Models.TblProduct", b =>
                {
                    b.Navigation("TblProductMappings");

                    b.Navigation("TblRatings");
                });

            modelBuilder.Entity("StyleSphere.Models.TblProductMapping", b =>
                {
                    b.Navigation("TblOrderDetails");
                });

            modelBuilder.Entity("StyleSphere.Models.TblSizeMaster", b =>
                {
                    b.Navigation("TblProductMappings");
                });

            modelBuilder.Entity("StyleSphere.Models.TblSubCategory", b =>
                {
                    b.Navigation("TblProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
