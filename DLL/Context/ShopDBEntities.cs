﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DLL.Models;

namespace DLL.Context
{
    public partial class ShopDBEntities : DbContext
    {
        public ShopDBEntities()
        {
        }

        public ShopDBEntities(DbContextOptions<ShopDBEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<AAccount> AAccount { get; set; }
        public virtual DbSet<ALedgerEntry> ALedgerEntry { get; set; }
        public virtual DbSet<ATransaction> ATransaction { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Enumaration> Enumaration { get; set; }
        public virtual DbSet<GroupProduct> GroupProduct { get; set; }
        public virtual DbSet<MasterInventory> MasterInventory { get; set; }
        public virtual DbSet<MasterInventoryLog> MasterInventoryLog { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderLog> OrderLog { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPrice> ProductPrice { get; set; }
        public virtual DbSet<ProductPriceLog> ProductPriceLog { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public virtual DbSet<SpecialOffer> SpecialOffer { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockLog> StockLog { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VwProduct> VwProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=ShopDbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Account__349DA5A6D8454BAB");

                entity.ToTable("A_Account");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ALedgerEntry>(entity =>
            {
                entity.HasKey(e => e.LedgerEntryId)
                    .HasName("PK__LedgerEn__ACE98A3AB97B89A1");

                entity.ToTable("A_LedgerEntry");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Credit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Debit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MtranId).HasColumnName("MTranId");

                entity.Property(e => e.UpdatedBy).HasMaxLength(10);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ATransaction>(entity =>
            {
                entity.HasKey(e => e.ATranId)
                    .HasName("PK_MTran_Id");

                entity.ToTable("A_Transaction");

                entity.Property(e => e.ATranId).HasColumnName("A_TranID");

                entity.Property(e => e.AuthorizedBy).HasMaxLength(10);

                entity.Property(e => e.AuthorizedDate).HasColumnType("datetime");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.PartyAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PartyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryCode).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Enumaration>(entity =>
            {
                entity.HasKey(e => e.EnumId);

                entity.Property(e => e.EnumId).HasColumnName("EnumID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<GroupProduct>(entity =>
            {
                entity.HasKey(e => e.ProductGroupId);

                entity.Property(e => e.ProductGroupId).HasColumnName("ProductGroupID");

                entity.Property(e => e.ChildProductId).HasColumnName("ChildProductID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MasterProductId).HasColumnName("MasterProductID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MasterInventory>(entity =>
            {
                entity.HasKey(e => e.MinventoryId);

                entity.Property(e => e.MinventoryId).HasColumnName("MInventoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MasterInventoryLog>(entity =>
            {
                entity.HasKey(e => e.MinventoryLogId);

                entity.Property(e => e.MinventoryLogId).HasColumnName("MInventoryLogID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MinventoryId).HasColumnName("MInventoryID");

                entity.Property(e => e.OperationDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DeliveryCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeliveryDate).HasMaxLength(50);

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderCode).HasMaxLength(50);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderType).HasMaxLength(50);

                entity.Property(e => e.OtherCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VatPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OtherCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VatPercent).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetails_Product");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_OrderDetails_Unit");
            });

            modelBuilder.Entity<OrderLog>(entity =>
            {
                entity.Property(e => e.OrderLogId).HasColumnName("OrderLogID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CardNo).HasMaxLength(50);

                entity.Property(e => e.ChangeAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChqueNo).HasMaxLength(50);

                entity.Property(e => e.CrDr).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DueAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Payment_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitType).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_Product_SubCategory");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_Product_Unit");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.Property(e => e.ProductPriceId).HasColumnName("ProductPriceID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Ppdiscount)
                    .HasColumnName("PPDiscount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PpotherCharge)
                    .HasColumnName("PPOtherCharge")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ppvat)
                    .HasColumnName("PPVat")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PpvatIncluded).HasColumnName("PPVatIncluded");

                entity.Property(e => e.PpvatPercent)
                    .HasColumnName("PPVatPercent")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Spdiscount)
                    .HasColumnName("SPDiscount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SpotherCharge)
                    .HasColumnName("SPOtherCharge")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Spvat)
                    .HasColumnName("SPVat")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SpvatIncluded).HasColumnName("SPVatIncluded");

                entity.Property(e => e.SpvatPercent)
                    .HasColumnName("SPVatPercent")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalSalesPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitSalesPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPrice)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductPrice_Product");
            });

            modelBuilder.Entity<ProductPriceLog>(entity =>
            {
                entity.Property(e => e.ProductPriceLogId)
                    .HasColumnName("ProductPriceLogID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PpotherCharge)
                    .HasColumnName("PPOtherCharge")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ppvat)
                    .HasColumnName("PPVat")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PpvatIncluded).HasColumnName("PPVatIncluded");

                entity.Property(e => e.PpvatPercent)
                    .HasColumnName("PPVatPercent")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductPriceId).HasColumnName("ProductPriceID");

                entity.Property(e => e.SpotherCharge)
                    .HasColumnName("SPOtherCharge")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Spvat)
                    .HasColumnName("SPVat")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SpvatIncluded).HasColumnName("SPVatIncluded");

                entity.Property(e => e.SpvatPercent)
                    .HasColumnName("SPVatPercent")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalSalesPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitSalesPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ProductPrice)
                    .WithMany(p => p.ProductPriceLog)
                    .HasForeignKey(d => d.ProductPriceId)
                    .HasConstraintName("FK_ProductPriceLog_ProductPrice");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PorderId);

                entity.Property(e => e.PorderId).HasColumnName("POrderID");

                entity.Property(e => e.AdditionalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderType).HasMaxLength(50);

                entity.Property(e => e.PorderCode)
                    .HasColumnName("POrderCode")
                    .HasMaxLength(50);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdvance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDeliveryCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalOtherCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VatPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");
            });

            modelBuilder.Entity<PurchaseOrderDetails>(entity =>
            {
                entity.HasKey(e => e.PorderDetailsId);

                entity.Property(e => e.PorderDetailsId).HasColumnName("POrderDetailsID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OtherCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PorderId).HasColumnName("POrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalUnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VatPercent).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Porder)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.PorderId)
                    .HasConstraintName("FK_PurchaseOrderDetails_PurchaseOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PurchaseOrderDetails_Product");
            });

            modelBuilder.Entity<SpecialOffer>(entity =>
            {
                entity.Property(e => e.SpecialOfferId).HasColumnName("SpecialOfferID");

                entity.Property(e => e.CashBackPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OfferEndDate).HasColumnType("datetime");

                entity.Property(e => e.OfferStartDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TotalCashBack).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId).HasColumnName("StockID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Stock_Product");
            });

            modelBuilder.Entity<StockLog>(entity =>
            {
                entity.Property(e => e.StockLogId).HasColumnName("StockLogID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OperationDate).HasColumnType("datetime");

                entity.Property(e => e.StockId).HasColumnName("StockID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.SubCategoryCode).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SubCategory_Category");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UnitName).HasMaxLength(50);

                entity.Property(e => e.UnitType).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.ContactPerson).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mobile1).HasMaxLength(20);

                entity.Property(e => e.Mobile2).HasMaxLength(20);

                entity.Property(e => e.OfficePhone).HasMaxLength(20);
            });

            modelBuilder.Entity<VwProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Product");

                entity.Property(e => e.AvaliableQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SaleDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaleOtherCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaleTotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaleUnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaleVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
