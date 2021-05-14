﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KakaoExpenseClaim.ClaimManagement.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseClaims",
                columns: table => new
                {
                    ExpenseClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequesterComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproverId = table.Column<int>(type: "int", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproverComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinanceId = table.Column<int>(type: "int", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinanceComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseClaims", x => x.ExpenseClaimId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PayeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    USDAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Receipt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ExpenseClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_ExpenseClaims_ExpenseClaimId",
                        column: x => x.ExpenseClaimId,
                        principalTable: "ExpenseClaims",
                        principalColumn: "ExpenseClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "RO", "Rent Office" },
                    { 9, "WS", "Website and software expenses" },
                    { 8, "AM", "Advertising and marketing" },
                    { 7, "MC", "Machinery" },
                    { 6, "EQ", "Equipment" },
                    { 10, "ET", "Entertainment" },
                    { 4, "FUR", "Furniture" },
                    { 3, "UT", "Utilities" },
                    { 2, "HO", "Home office costs" },
                    { 5, "SPP", "Office supplies" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "EUR", "€" },
                    { 2, "KRW", "₩" },
                    { 3, "CAD", "C$" },
                    { 4, "JPN", "¥" },
                    { 5, "USD", "$" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseClaims",
                columns: new[] { "ExpenseClaimId", "ApprovalDate", "ApproverComments", "ApproverId", "CreatedBy", "CreatedDate", "FinanceComments", "FinanceId", "LastModifiedBy", "LastModifiedDate", "ProcessedDate", "RequesterComments", "RequesterId", "Status", "SubmitDate", "Title", "TotalAmount" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000546, 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(77), "Expense Claim case 4", 5840m },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 13, 22, 4, 27, 635, DateTimeKind.Local).AddTicks(3840), "Expense Claim case 1", 60915m },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000319, 1, new DateTime(2021, 11, 13, 22, 4, 27, 641, DateTimeKind.Local).AddTicks(9991), "Expense Claim case 2", 27098m },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000812, 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(55), "Expense Claim case 3", 60227m },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000173, 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(94), "Expense Claim case 5", 16434m }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Amount", "CategoryId", "CreatedBy", "CreatedDate", "CurrencyId", "Date", "Description", "ExpenseClaimId", "LastModifiedBy", "LastModifiedDate", "PayeeId", "Receipt", "USDAmount" },
                values: new object[,]
                {
                    { 2, 50000m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5348), "	Utilities, Jan 2019	", 1, null, null, 21000365, null, 45m },
                    { 21, 1046m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5789), "	Advertising and marketing, Feb 2020	", 5, null, null, 21000173, null, 1266m },
                    { 16, 3454m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5691), "	Website and software expenses, Nov 2021	", 5, null, null, 21000546, null, 4179m },
                    { 11, 4435m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5593), "	Office supplies, May 2021	", 5, null, null, 21000812, null, 5366m },
                    { 6, 645m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5447), "	Website and software expenses, Nov 2021	", 5, null, null, 21000319, null, 780m },
                    { 1, 240m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(2170), "	Home office costs, Feb 2020	", 5, null, null, 21000986, null, 290m },
                    { 34, 3058m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6103), "	Rental fee  Nov 2021	", 4, null, null, 21000546, null, 2508m },
                    { 29, 100587m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6010), "	Furniture, March 2020	", 4, null, null, 21000812, null, 915m },
                    { 24, 42300m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5844), "	Furniture, March 2020	", 4, null, null, 21000319, null, 385m },
                    { 19, 59430m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5749), "	Office supplies, May 2021	", 4, null, null, 21000986, null, 541m },
                    { 14, 38740m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5652), "	Advertising and marketing, Feb 2020	", 4, null, null, 21000365, null, 353m },
                    { 9, 105070m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5510), "	Entertainment, Oct 2018	", 4, null, null, 21000173, null, 956m },
                    { 4, 20000m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5403), "	Advertising and marketing, Feb 2020	", 4, null, null, 21000546, null, 182m },
                    { 33, 3080000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6083), "	Rental fee  Nov 2021	", 3, null, null, 21000173, null, 2741m },
                    { 28, 578m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5990), "	Furniture, March 2020	", 3, null, null, 21000546, null, 474m },
                    { 23, 54986m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5826), "	Advertising and marketing, Feb 2020	", 3, null, null, 21000812, null, 45089m },
                    { 18, 3497m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5730), "	Entertainment, Oct 2018	", 3, null, null, 21000319, null, 2868m },
                    { 13, 5446m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5632), "	Advertising and marketing, Feb 2020	", 3, null, null, 21000986, null, 4466m },
                    { 7, 770000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5467), "	Office supplies, Sept 2019	", 1, null, null, 21000986, null, 685m },
                    { 12, 450000m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5613), "	Office supplies, Sept 2019	", 1, null, null, 21000319, null, 401m },
                    { 17, 650000m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5710), "	Furniture, March 2020	", 1, null, null, 21000812, null, 579m },
                    { 22, 8000000m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5808), "	Website and software expenses, Nov 2021	", 1, null, null, 21000546, null, 7120m },
                    { 27, 895320m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5972), "	Advertising and marketing, Feb 2020	", 1, null, null, 21000173, null, 797m },
                    { 32, 42387m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6065), "	bought a car	", 1, null, null, 21000365, null, 51288m },
                    { 26, 3096m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5950), "	Advertising and marketing, Feb 2020	", 5, null, null, 21000365, null, 3746m },
                    { 5, 5567m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5423), "	Entertainment, Oct 2018	", 2, null, null, 21000812, null, 5567m },
                    { 15, 234m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5671), "	Office supplies, Sept 2019	", 2, null, null, 21000173, null, 234m },
                    { 20, 10890m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5768), "	Advertising and marketing, Feb 2020	", 2, null, null, 21000365, null, 10890m },
                    { 25, 3067m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5862), "	Office supplies, Sept 2019	", 2, null, null, 21000986, null, 3067m },
                    { 30, 3480m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6028), "	Furniture, March 2020	", 2, null, null, 21000319, null, 3480m },
                    { 3, 240m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5383), "	Furniture, March 2020	", 3, null, null, 21000173, null, 197m },
                    { 8, 5356m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5491), "	Office supplies, Sept 2019	", 3, null, null, 21000365, null, 4392m },
                    { 10, 3860m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(5571), "	Utilities, Jan 2019	", 2, null, null, 21000546, null, 3860m },
                    { 31, 88659m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 13, 22, 4, 27, 642, DateTimeKind.Local).AddTicks(6047), "	Requesting claimsB	", 5, null, null, 21000986, null, 807m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ExpenseClaimId",
                table: "Items",
                column: "ExpenseClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ExpenseClaims");
        }
    }
}
