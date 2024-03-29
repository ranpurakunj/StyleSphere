﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StyleSphere.Models;

public partial class DbStyleSphereContext : DbContext
{
    public DbStyleSphereContext()
    {
    }

    public DbStyleSphereContext(DbContextOptions<DbStyleSphereContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblColorMaster> TblColorMasters { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblFavorite> TblFavorites { get; set; }

    public virtual DbSet<TblOrderDatum> TblOrderData { get; set; }

    public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductMapping> TblProductMappings { get; set; }

    public virtual DbSet<TblRating> TblRatings { get; set; }

    public virtual DbSet<TblSizeMaster> TblSizeMasters { get; set; }

    public virtual DbSet<TblSubCategory> TblSubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KUNJ;Database=StyleSphereDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("Categories");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
        });

        modelBuilder.Entity<TblColorMaster>(entity =>
        {
            entity.HasKey(e => e.ColorId);

            entity.ToTable("ColorMaster");

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("Customers");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblFavorite>(entity =>
        {

            entity.HasKey(e => e.FavoriteId);
            entity.ToTable("Favorites");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FavoriteId)
                .ValueGeneratedOnAdd()
                .HasColumnName("FavoritesID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(f=>f.TblFavorites)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Customers");

            entity.HasOne(d => d.Product).WithMany(f => f.TblFavorites)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Products");
        });

        modelBuilder.Entity<TblOrderDatum>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("OrdersData");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.BillingAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TrackingId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TrackingID");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblOrderData)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersData_Customers");
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);

            entity.ToTable("OrderDetails");

            entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ProductMappingId).HasColumnName("ProductMappingID");
            entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_OrdersData");

            entity.HasOne(d => d.ProductMapping).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.ProductMappingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_ProductMappings");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Products");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Image1).IsUnicode(false);
            entity.Property(e => e.Image2).IsUnicode(false);
            entity.Property(e => e.Image3).IsUnicode(false);
            entity.Property(e => e.MfgDate).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");
            entity.Property(e => e.ThumbnailImage).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Sub_Categories");
        });

        modelBuilder.Entity<TblProductMapping>(entity =>
        {
            entity.HasKey(e => e.ProductMappingId);

            entity.ToTable("ProductMappings");

            entity.Property(e => e.ProductMappingId).HasColumnName("ProductMappingID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SizeId).HasColumnName("SizeID");

            entity.HasOne(d => d.Color).WithMany(p => p.TblProductMappings)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductMappings_ColorMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProductMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductMappings_Products");

            entity.HasOne(d => d.Size).WithMany(p => p.TblProductMappings)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductMappings_SizesMaster");
        });

        modelBuilder.Entity<TblRating>(entity =>
        {
            entity.HasKey(e => e.RatingId);

            entity.ToTable("Ratings");

            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblRatings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ratings_Customers");

            entity.HasOne(d => d.Product).WithMany(p => p.TblRatings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ratings_Products");
        });

        modelBuilder.Entity<TblSizeMaster>(entity =>
        {
            entity.HasKey(e => e.SizeId);

            entity.ToTable("SizesMaster");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.Eusize).HasColumnName("EUSize");
            entity.Property(e => e.Ussize).HasColumnName("USSize");
        });

        modelBuilder.Entity<TblSubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId);

            entity.ToTable("Sub_Categories");

            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.SubCategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.TblSubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sub_Categories_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
