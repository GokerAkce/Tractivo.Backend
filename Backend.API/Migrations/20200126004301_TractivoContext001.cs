using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.API.Migrations
{
    public partial class TractivoContext001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    PaymentRangeType = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Country", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, "35 Carlberg Avenue", "Oxford", "UK", "mpeel@localhost.com", "Mark", "Peel", "05555555555" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Country", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 2, "25 Kebel Road", "Oxford", "UK", "jcursy@localhost.com", "John", "Cursy", "05555555555" });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "CustomerId", "EndDate", "Name", "PaymentRangeType", "Price", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2020, 5, 26, 0, 43, 0, 478, DateTimeKind.Local).AddTicks(4401), "Short Time Tenancy Contract", 0, 750.0, new DateTime(2020, 1, 26, 0, 43, 0, 477, DateTimeKind.Local).AddTicks(1304) });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceNumber", "MaturityDate", "Price", "StartDate" },
                values: new object[] { 1, 1, "AAA000", new DateTime(2020, 2, 10, 0, 43, 0, 478, DateTimeKind.Local).AddTicks(8053), 350.0, new DateTime(2020, 1, 26, 0, 43, 0, 478, DateTimeKind.Local).AddTicks(8040) });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerId",
                table: "Contracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
