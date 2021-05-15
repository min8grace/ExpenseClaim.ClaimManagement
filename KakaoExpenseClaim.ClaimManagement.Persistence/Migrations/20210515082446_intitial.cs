using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KakaoExpenseClaim.ClaimManagement.Persistence.Migrations
{
    public partial class intitial : Migration
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
                    { 2, "HO", "Home office costs" },
                    { 3, "UT", "Utilities" },
                    { 4, "FUR", "Furniture" },
                    { 5, "SPP", "Office supplies" },
                    { 6, "EQ", "Equipment" },
                    { 7, "MC", "Machinery" },
                    { 8, "AM", "Advertising and marketing" },
                    { 9, "WS", "Website and software expenses" },
                    { 10, "ET", "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 4, "JPN", "¥" },
                    { 3, "CAD", "C$" },
                    { 5, "USD", "$" },
                    { 1, "EUR", "€" },
                    { 2, "KRW", "₩" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseClaims",
                columns: new[] { "ExpenseClaimId", "ApprovalDate", "ApproverComments", "ApproverId", "CreatedBy", "CreatedDate", "FinanceComments", "FinanceId", "LastModifiedBy", "LastModifiedDate", "ProcessedDate", "RequesterComments", "RequesterId", "Status", "SubmitDate", "Title", "TotalAmount" },
                values: new object[,]
                {
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000812, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6121), "Expense Claim case 13", 80227m },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000319, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6109), "Expense Claim case 12", 97098m },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6093), "Expense Claim case 11", 50915m },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000173, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6080), "Expense Claim case 10", 76434m },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000546, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6066), "Expense Claim case 9", 3840m },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000812, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6053), "Expense Claim case 8", 10227m },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000319, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6039), "Expense Claim case 7", 77098m },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6010), "Expense Claim case 5", 16434m },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(5997), "Expense Claim case 4", 5840m },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(5980), "Expense Claim case 3", 60227m },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(5936), "Expense Claim case 2", 27098m },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 15, 1, 24, 46, 250, DateTimeKind.Local).AddTicks(3796), "Expense Claim case 1", 60915m },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000546, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6168), "Expense Claim case 14", 4840m },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000986, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6026), "Expense Claim case 6", 63415m },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "please, check this out and approve it	", 21000173, 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(6183), "Expense Claim case 15", 26434m }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Amount", "CategoryId", "CreatedBy", "CreatedDate", "CurrencyId", "Date", "Description", "ExpenseClaimId", "LastModifiedBy", "LastModifiedDate", "PayeeId", "Receipt", "USDAmount" },
                values: new object[,]
                {
                    { 2, 50000m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9852), "	Utilities, Jan 2019	", 1, null, null, 21000365, null, 45m },
                    { 11, 4435m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(4), "	Office supplies, May 2021	", 5, null, null, 21000812, null, 5366m },
                    { 16, 3454m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(105), "	Website and software expenses, Nov 2021	", 5, null, null, 21000546, null, 4179m },
                    { 21, 1046m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(178), "	Advertising and marketing, Feb 2020	", 5, null, null, 21000173, null, 1266m },
                    { 26, 3096m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(251), "	Advertising and marketing, Feb 2020	", 5, null, null, 21000365, null, 3746m },
                    { 31, 88659m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(330), "	Requesting claimsB	", 5, null, null, 21000986, null, 807m },
                    { 40, 3480m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(414), "	Furniture, March 2020	", 6, null, null, 21000319, null, 3480m },
                    { 41, 88659m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(429), "	Requesting claimsB	", 6, null, null, 21000986, null, 807m },
                    { 42, 42387m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(443), "	bought a car	", 6, null, null, 21000365, null, 51288m },
                    { 43, 3080000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(457), "	Rental fee  Nov 2021	", 7, null, null, 21000173, null, 2741m },
                    { 44, 3058m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(471), "	Rental fee  Nov 2021	", 7, null, null, 21000546, null, 2508m },
                    { 45, 3480m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(484), "	Furniture, March 2020	", 7, null, null, 21000319, null, 3480m },
                    { 46, 88659m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(498), "	Requesting claimsB	", 7, null, null, 21000986, null, 807m },
                    { 47, 42387m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(512), "	bought a car	", 8, null, null, 21000365, null, 51288m },
                    { 48, 3080000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(526), "	Rental fee  Nov 2021	", 8, null, null, 21000173, null, 2741m },
                    { 49, 3058m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(540), "	Rental fee  Nov 2021	", 8, null, null, 21000546, null, 2508m },
                    { 50, 3480m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(553), "	Furniture, March 2020	", 9, null, null, 21000319, null, 3480m },
                    { 51, 88659m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(567), "	Requesting claimsB	", 9, null, null, 21000986, null, 807m },
                    { 52, 42387m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(581), "	bought a car	", 9, null, null, 21000365, null, 51288m },
                    { 53, 3080000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(616), "	Rental fee  Nov 2021	", 10, null, null, 21000173, null, 2741m },
                    { 54, 3058m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(630), "	Rental fee  Nov 2021	", 10, null, null, 21000546, null, 2508m },
                    { 55, 3480m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(645), "	Furniture, March 2020	", 11, null, null, 21000319, null, 3480m },
                    { 56, 88659m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(659), "	Requesting claimsB	", 12, null, null, 21000986, null, 807m },
                    { 57, 42387m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(672), "	bought a car	", 13, null, null, 21000365, null, 51288m },
                    { 6, 645m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9931), "	Website and software expenses, Nov 2021	", 5, null, null, 21000319, null, 780m },
                    { 1, 240m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(7698), "	Home office costs, Feb 2020	", 5, null, null, 21000986, null, 290m },
                    { 34, 3058m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(399), "	Rental fee  Nov 2021	", 4, null, null, 21000546, null, 2508m },
                    { 29, 100587m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(298), "	Furniture, March 2020	", 4, null, null, 21000812, null, 915m },
                    { 7, 770000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9945), "	Office supplies, Sept 2019	", 1, null, null, 21000986, null, 685m },
                    { 12, 450000m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(18), "	Office supplies, Sept 2019	", 1, null, null, 21000319, null, 401m },
                    { 17, 650000m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(118), "	Furniture, March 2020	", 1, null, null, 21000812, null, 579m },
                    { 22, 8000000m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(191), "	Website and software expenses, Nov 2021	", 1, null, null, 21000546, null, 7120m },
                    { 27, 895320m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(266), "	Advertising and marketing, Feb 2020	", 1, null, null, 21000173, null, 797m },
                    { 32, 42387m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(368), "	bought a car	", 1, null, null, 21000365, null, 51288m },
                    { 5, 5567m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9914), "	Entertainment, Oct 2018	", 2, null, null, 21000812, null, 5567m },
                    { 10, 3860m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9990), "	Utilities, Jan 2019	", 2, null, null, 21000546, null, 3860m },
                    { 15, 234m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(88), "	Office supplies, Sept 2019	", 2, null, null, 21000173, null, 234m },
                    { 20, 10890m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(164), "	Advertising and marketing, Feb 2020	", 2, null, null, 21000365, null, 10890m },
                    { 25, 3067m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(237), "	Office supplies, Sept 2019	", 2, null, null, 21000986, null, 3067m },
                    { 58, 3080000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(686), "	Rental fee  Nov 2021	", 14, null, null, 21000173, null, 2741m },
                    { 30, 3480m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(314), "	Furniture, March 2020	", 2, null, null, 21000319, null, 3480m },
                    { 8, 5356m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9960), "	Office supplies, Sept 2019	", 3, null, null, 21000365, null, 4392m }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Amount", "CategoryId", "CreatedBy", "CreatedDate", "CurrencyId", "Date", "Description", "ExpenseClaimId", "LastModifiedBy", "LastModifiedDate", "PayeeId", "Receipt", "USDAmount" },
                values: new object[,]
                {
                    { 13, 5446m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(34), "	Advertising and marketing, Feb 2020	", 3, null, null, 21000986, null, 4466m },
                    { 18, 3497m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(134), "	Entertainment, Oct 2018	", 3, null, null, 21000319, null, 2868m },
                    { 23, 54986m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(205), "	Advertising and marketing, Feb 2020	", 3, null, null, 21000812, null, 45089m },
                    { 28, 578m, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(282), "	Furniture, March 2020	", 3, null, null, 21000546, null, 474m },
                    { 33, 3080000m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(382), "	Rental fee  Nov 2021	", 3, null, null, 21000173, null, 2741m },
                    { 4, 20000m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9897), "	Advertising and marketing, Feb 2020	", 4, null, null, 21000546, null, 182m },
                    { 9, 105070m, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9974), "	Entertainment, Oct 2018	", 4, null, null, 21000173, null, 956m },
                    { 14, 38740m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(48), "	Advertising and marketing, Feb 2020	", 4, null, null, 21000365, null, 353m },
                    { 19, 59430m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(149), "	Office supplies, May 2021	", 4, null, null, 21000986, null, 541m },
                    { 24, 42300m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(223), "	Furniture, March 2020	", 4, null, null, 21000319, null, 385m },
                    { 3, 240m, 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 253, DateTimeKind.Local).AddTicks(9881), "	Furniture, March 2020	", 3, null, null, 21000173, null, 197m },
                    { 59, 3058m, 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 1, 24, 46, 254, DateTimeKind.Local).AddTicks(700), "	Rental fee  Nov 2021	", 15, null, null, 21000546, null, 2508m }
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
