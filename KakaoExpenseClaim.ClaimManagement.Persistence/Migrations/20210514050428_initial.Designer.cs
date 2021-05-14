﻿// <auto-generated />
using System;
using KakaoExpenseClaim.ClaimManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KakaoExpenseClaim.ClaimManagement.Persistence.Migrations
{
    [DbContext(typeof(ExpenseClaimDbContext))]
    [Migration("20210514050428_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KakaoExpenseClaim.ClaimManagement.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

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
                            Code = "RO",
                            Name = "Rent Office"
                        },
                        new
                        {
                            Id = 2,
                            Code = "HO",
                            Name = "Home office costs"
                        },
                        new
                        {
                            Id = 3,
                            Code = "UT",
                            Name = "Utilities"
                        },
                        new
                        {
                            Id = 4,
                            Code = "FUR",
                            Name = "Furniture"
                        },
                        new
                        {
                            Id = 5,
                            Code = "SPP",
                            Name = "Office supplies"
                        },
                        new
                        {
                            Id = 6,
                            Code = "EQ",
                            Name = "Equipment"
                        },
                        new
                        {
                            Id = 7,
                            Code = "MC",
                            Name = "Machinery"
                        },
                        new
                        {
                            Id = 8,
                            Code = "AM",
                            Name = "Advertising and marketing"
                        },
                        new
                        {
                            Id = 9,
                            Code = "WS",
                            Name = "Website and software expenses"
                        },
                        new
                        {
                            Id = 10,
                            Code = "ET",
                            Name = "Entertainment"
                        });
                });

            modelBuilder.Entity("KakaoExpenseClaim.ClaimManagement.Domain.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "EUR",
                            Symbol = "€"
                        },
                        new
                        {
                            Id = 2,
                            Name = "KRW",
                            Symbol = "₩"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CAD",
                            Symbol = "C$"
                        },
                        new
                        {
                            Id = 4,
                            Name = "JPN",
                            Symbol = "¥"
                        },
                        new
                        {
                            Id = 5,
                            Name = "USD",
                            Symbol = "$"
                        });
                });

            modelBuilder.Entity("KakaoExpenseClaim.ClaimManagement.Domain.Entities.ExpenseClaim", b =>
                {
                    b.Property<int>("ExpenseClaimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApproverComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinanceComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinanceId")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequesterComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequesterId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ExpenseClaimId");

                    b.ToTable("ExpenseClaims");

                    b.HasData(
                        new
                        {
                            ExpenseClaimId = 1,
                            ApprovalDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApproverId = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinanceId = 0,
                            ProcessedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequesterComments = "please, check this out and approve it	",
                            RequesterId = 21000986,
                            Status = 1,
                            SubmitDate = new DateTime(2021, 11, 13, 22, 4, 27, 635, DateTimeKind.Local).AddTicks(3840),
                            Title = "Expense Claim case 1",
                            TotalAmount = 60915m
                        },
                        new
                        {
                            ExpenseClaimId = 2,
                            ApprovalDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApproverId = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinanceId = 0,
                            ProcessedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequesterComments = "please, check this out and approve it	",
                            RequesterId = 21000319,
                            Status = 1,
                            SubmitDate = new DateTime(2021, 11, 13, 22, 4, 27, 641, DateTimeKind.Local).AddTicks(9991),
                            Title = "Expense Claim case 2",
                            TotalAmount = 27098m
                        },
                        new
                        {
                            ExpenseClaimId = 3,
                            ApprovalDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApproverId = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinanceId = 0,
                            ProcessedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequesterComments = "please, check this out and approve it	",
                            RequesterId = 21000812,
                            Status = 1,
                            SubmitDate = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(55),
                            Title = "Expense Claim case 3",
                            TotalAmount = 60227m
                        },
                        new
                        {
                            ExpenseClaimId = 4,
                            ApprovalDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApproverId = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinanceId = 0,
                            ProcessedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequesterComments = "please, check this out and approve it	",
                            RequesterId = 21000546,
                            Status = 1,
                            SubmitDate = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(77),
                            Title = "Expense Claim case 4",
                            TotalAmount = 5840m
                        },
                        new
                        {
                            ExpenseClaimId = 5,
                            ApprovalDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApproverId = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinanceId = 0,
                            ProcessedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequesterComments = "please, check this out and approve it	",
                            RequesterId = 21000173,
                            Status = 1,
                            SubmitDate = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(94),
                            Title = "Expense Claim case 5",
                            TotalAmount = 16434m
                        });
                });

            modelBuilder.Entity("KakaoExpenseClaim.ClaimManagement.Domain.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpenseClaimId")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PayeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Receipt")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("USDAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId");

                    b.HasIndex("ExpenseClaimId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Amount = 240m,
                            CategoryId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 1,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(2170),
                            Description = "	Home office costs, Feb 2020	",
                            ExpenseClaimId = 5,
                            PayeeId = 21000986,
                            USDAmount = 290m
                        },
                        new
                        {
                            ItemId = 2,
                            Amount = 50000m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 2,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5348),
                            Description = "	Utilities, Jan 2019	",
                            ExpenseClaimId = 1,
                            PayeeId = 21000365,
                            USDAmount = 45m
                        },
                        new
                        {
                            ItemId = 3,
                            Amount = 240m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 3,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5383),
                            Description = "	Furniture, March 2020	",
                            ExpenseClaimId = 3,
                            PayeeId = 21000173,
                            USDAmount = 197m
                        },
                        new
                        {
                            ItemId = 4,
                            Amount = 20000m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 4,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5403),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 4,
                            PayeeId = 21000546,
                            USDAmount = 182m
                        },
                        new
                        {
                            ItemId = 5,
                            Amount = 5567m,
                            CategoryId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 5,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5423),
                            Description = "	Entertainment, Oct 2018	",
                            ExpenseClaimId = 2,
                            PayeeId = 21000812,
                            USDAmount = 5567m
                        },
                        new
                        {
                            ItemId = 6,
                            Amount = 645m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 1,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5447),
                            Description = "	Website and software expenses, Nov 2021	",
                            ExpenseClaimId = 5,
                            PayeeId = 21000319,
                            USDAmount = 780m
                        },
                        new
                        {
                            ItemId = 7,
                            Amount = 770000m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 2,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5467),
                            Description = "	Office supplies, Sept 2019	",
                            ExpenseClaimId = 1,
                            PayeeId = 21000986,
                            USDAmount = 685m
                        },
                        new
                        {
                            ItemId = 8,
                            Amount = 5356m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 3,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5491),
                            Description = "	Office supplies, Sept 2019	",
                            ExpenseClaimId = 3,
                            PayeeId = 21000365,
                            USDAmount = 4392m
                        },
                        new
                        {
                            ItemId = 9,
                            Amount = 105070m,
                            CategoryId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 4,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5510),
                            Description = "	Entertainment, Oct 2018	",
                            ExpenseClaimId = 4,
                            PayeeId = 21000173,
                            USDAmount = 956m
                        },
                        new
                        {
                            ItemId = 10,
                            Amount = 3860m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 5,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5571),
                            Description = "	Utilities, Jan 2019	",
                            ExpenseClaimId = 2,
                            PayeeId = 21000546,
                            USDAmount = 3860m
                        },
                        new
                        {
                            ItemId = 11,
                            Amount = 4435m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 1,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5593),
                            Description = "	Office supplies, May 2021	",
                            ExpenseClaimId = 5,
                            PayeeId = 21000812,
                            USDAmount = 5366m
                        },
                        new
                        {
                            ItemId = 12,
                            Amount = 450000m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 2,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5613),
                            Description = "	Office supplies, Sept 2019	",
                            ExpenseClaimId = 1,
                            PayeeId = 21000319,
                            USDAmount = 401m
                        },
                        new
                        {
                            ItemId = 13,
                            Amount = 5446m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 3,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5632),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 3,
                            PayeeId = 21000986,
                            USDAmount = 4466m
                        },
                        new
                        {
                            ItemId = 14,
                            Amount = 38740m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 4,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5652),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 4,
                            PayeeId = 21000365,
                            USDAmount = 353m
                        },
                        new
                        {
                            ItemId = 15,
                            Amount = 234m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 5,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5671),
                            Description = "	Office supplies, Sept 2019	",
                            ExpenseClaimId = 2,
                            PayeeId = 21000173,
                            USDAmount = 234m
                        },
                        new
                        {
                            ItemId = 16,
                            Amount = 3454m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 1,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5691),
                            Description = "	Website and software expenses, Nov 2021	",
                            ExpenseClaimId = 5,
                            PayeeId = 21000546,
                            USDAmount = 4179m
                        },
                        new
                        {
                            ItemId = 17,
                            Amount = 650000m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 2,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5710),
                            Description = "	Furniture, March 2020	",
                            ExpenseClaimId = 1,
                            PayeeId = 21000812,
                            USDAmount = 579m
                        },
                        new
                        {
                            ItemId = 18,
                            Amount = 3497m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 3,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5730),
                            Description = "	Entertainment, Oct 2018	",
                            ExpenseClaimId = 3,
                            PayeeId = 21000319,
                            USDAmount = 2868m
                        },
                        new
                        {
                            ItemId = 19,
                            Amount = 59430m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 4,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5749),
                            Description = "	Office supplies, May 2021	",
                            ExpenseClaimId = 4,
                            PayeeId = 21000986,
                            USDAmount = 541m
                        },
                        new
                        {
                            ItemId = 20,
                            Amount = 10890m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 5,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5768),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 2,
                            PayeeId = 21000365,
                            USDAmount = 10890m
                        },
                        new
                        {
                            ItemId = 21,
                            Amount = 1046m,
                            CategoryId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 1,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5789),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 5,
                            PayeeId = 21000173,
                            USDAmount = 1266m
                        },
                        new
                        {
                            ItemId = 22,
                            Amount = 8000000m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 2,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5808),
                            Description = "	Website and software expenses, Nov 2021	",
                            ExpenseClaimId = 1,
                            PayeeId = 21000546,
                            USDAmount = 7120m
                        },
                        new
                        {
                            ItemId = 23,
                            Amount = 54986m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 3,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5826),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 3,
                            PayeeId = 21000812,
                            USDAmount = 45089m
                        },
                        new
                        {
                            ItemId = 24,
                            Amount = 42300m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 4,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5844),
                            Description = "	Furniture, March 2020	",
                            ExpenseClaimId = 4,
                            PayeeId = 21000319,
                            USDAmount = 385m
                        },
                        new
                        {
                            ItemId = 25,
                            Amount = 3067m,
                            CategoryId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 5,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5862),
                            Description = "	Office supplies, Sept 2019	",
                            ExpenseClaimId = 2,
                            PayeeId = 21000986,
                            USDAmount = 3067m
                        },
                        new
                        {
                            ItemId = 26,
                            Amount = 3096m,
                            CategoryId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 1,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5950),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 5,
                            PayeeId = 21000365,
                            USDAmount = 3746m
                        },
                        new
                        {
                            ItemId = 27,
                            Amount = 895320m,
                            CategoryId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 2,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5972),
                            Description = "	Advertising and marketing, Feb 2020	",
                            ExpenseClaimId = 1,
                            PayeeId = 21000173,
                            USDAmount = 797m
                        },
                        new
                        {
                            ItemId = 28,
                            Amount = 578m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 3,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5990),
                            Description = "	Furniture, March 2020	",
                            ExpenseClaimId = 3,
                            PayeeId = 21000546,
                            USDAmount = 474m
                        },
                        new
                        {
                            ItemId = 29,
                            Amount = 100587m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 4,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6010),
                            Description = "	Furniture, March 2020	",
                            ExpenseClaimId = 4,
                            PayeeId = 21000812,
                            USDAmount = 915m
                        },
                        new
                        {
                            ItemId = 30,
                            Amount = 3480m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 5,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6028),
                            Description = "	Furniture, March 2020	",
                            ExpenseClaimId = 2,
                            PayeeId = 21000319,
                            USDAmount = 3480m
                        },
                        new
                        {
                            ItemId = 31,
                            Amount = 88659m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 4,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6047),
                            Description = "	Requesting claimsB	",
                            ExpenseClaimId = 5,
                            PayeeId = 21000986,
                            USDAmount = 807m
                        },
                        new
                        {
                            ItemId = 32,
                            Amount = 42387m,
                            CategoryId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 1,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6065),
                            Description = "	bought a car	",
                            ExpenseClaimId = 1,
                            PayeeId = 21000365,
                            USDAmount = 51288m
                        },
                        new
                        {
                            ItemId = 33,
                            Amount = 3080000m,
                            CategoryId = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 2,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6083),
                            Description = "	Rental fee  Nov 2021	",
                            ExpenseClaimId = 3,
                            PayeeId = 21000173,
                            USDAmount = 2741m
                        },
                        new
                        {
                            ItemId = 34,
                            Amount = 3058m,
                            CategoryId = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrencyId = 3,
                            Date = new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6103),
                            Description = "	Rental fee  Nov 2021	",
                            ExpenseClaimId = 4,
                            PayeeId = 21000546,
                            USDAmount = 2508m
                        });
                });

            modelBuilder.Entity("KakaoExpenseClaim.ClaimManagement.Domain.Entities.Item", b =>
                {
                    b.HasOne("KakaoExpenseClaim.ClaimManagement.Domain.Entities.ExpenseClaim", "ExpenseClaim")
                        .WithMany("Items")
                        .HasForeignKey("ExpenseClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseClaim");
                });

            modelBuilder.Entity("KakaoExpenseClaim.ClaimManagement.Domain.Entities.ExpenseClaim", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
