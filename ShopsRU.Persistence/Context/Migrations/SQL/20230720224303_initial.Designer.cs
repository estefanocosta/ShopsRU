﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopsRU.Persistence.Context.EntityFramework;

#nullable disable

namespace ShopsRU.Persistence.Context.Migrations.SQL
{
    [DbContext(typeof(ShopsRUContext))]
    [Migration("20230720224303_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopsRU.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 324, DateTimeKind.Local).AddTicks(684));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 324, DateTimeKind.Local).AddTicks(1542),
                            IsDeleted = false,
                            Name = "Mutfak"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 324, DateTimeKind.Local).AddTicks(1552),
                            IsDeleted = false,
                            Name = "Mobilya"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 324, DateTimeKind.Local).AddTicks(1554),
                            IsDeleted = false,
                            Name = "Market"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 324, DateTimeKind.Local).AddTicks(1555),
                            IsDeleted = false,
                            Name = "Aydınlatma"
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(5103));

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6325),
                            CustomerTypeId = 1,
                            FirstName = "EVREN",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6337),
                            LastName = "AKTAŞ"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6340),
                            CustomerTypeId = 2,
                            FirstName = "ECE",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6343),
                            LastName = "DAĞDELEN"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6344),
                            CustomerTypeId = 1,
                            FirstName = "İBRAHİM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6346),
                            LastName = "AKIŞIK"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6348),
                            CustomerTypeId = 2,
                            FirstName = "GİZEM",
                            IsDeleted = false,
                            JoiningDate = new DateTime(2023, 7, 21, 1, 43, 3, 318, DateTimeKind.Local).AddTicks(6350),
                            LastName = "KURTCUOĞLU"
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 317, DateTimeKind.Local).AddTicks(8140));

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("RuleJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("CustomerDiscounts");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(558));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(1416),
                            IsDeleted = false,
                            Type = "Mağaza Çalışanı"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(1422),
                            IsDeleted = false,
                            Type = "Mağaza Üyesi"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(1424),
                            IsDeleted = false,
                            Type = "Sadık Müşteri"
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(8526));

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(9349),
                            DiscountRate = 30,
                            DiscountType = "Yüzde",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(9355),
                            DiscountRate = 10,
                            DiscountType = "Yüzde",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 319, DateTimeKind.Local).AddTicks(9357),
                            DiscountRate = 5,
                            DiscountType = "Yüzde",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillingUserId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 320, DateTimeKind.Local).AddTicks(4615));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SaleId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 321, DateTimeKind.Local).AddTicks(20));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 321, DateTimeKind.Local).AddTicks(853),
                            IsDeleted = false,
                            Name = "Gardırop",
                            Price = 3000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 321, DateTimeKind.Local).AddTicks(862),
                            IsDeleted = false,
                            Name = "Fırın",
                            Price = 4000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 321, DateTimeKind.Local).AddTicks(864),
                            IsDeleted = false,
                            Name = "Fıstık Ezmesi",
                            Price = 85m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            CreatedBy = "EVREN AKTAŞ",
                            CreatedOn = new DateTime(2023, 7, 21, 1, 43, 3, 321, DateTimeKind.Local).AddTicks(866),
                            IsDeleted = false,
                            Name = "ModeLight Işıl 3'lü Avize",
                            Price = 4000m
                        });
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 323, DateTimeKind.Local).AddTicks(6204));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SellingUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.SaleDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 21, 1, 43, 3, 323, DateTimeKind.Local).AddTicks(280));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleDetails");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Customer", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.CustomerType", "CustomerType")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerDiscount", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.CustomerType", "CustomerType")
                        .WithMany("CustomerDiscounts")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopsRU.Domain.Entities.Discount", "Discounts")
                        .WithMany("CustomerDiscounts")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");

                    b.Navigation("Discounts");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopsRU.Domain.Entities.Sale", "Sale")
                        .WithMany("Invoices")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Product", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.SaleDetail", b =>
                {
                    b.HasOne("ShopsRU.Domain.Entities.Product", "Product")
                        .WithMany("SaleDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopsRU.Domain.Entities.Sale", "Sale")
                        .WithMany("SaleDetails")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.CustomerType", b =>
                {
                    b.Navigation("CustomerDiscounts");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Discount", b =>
                {
                    b.Navigation("CustomerDiscounts");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Product", b =>
                {
                    b.Navigation("SaleDetails");
                });

            modelBuilder.Entity("ShopsRU.Domain.Entities.Sale", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("SaleDetails");
                });
#pragma warning restore 612, 618
        }
    }
}