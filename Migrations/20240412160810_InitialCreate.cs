using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuarterlySalesApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DateOfHire", "FirstName", "LastName", "ManagerId" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", null },
                    { 2, new DateTime(1985, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", 1 },
                    { 3, new DateTime(1988, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Johnson", 1 },
                    { 4, new DateTime(1992, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Williams", 1 },
                    { 5, new DateTime(1983, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Brown", 1 },
                    { 6, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Jones", 1 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[,]
                {
                    { 1, 15000m, 1, 1, 2024 },
                    { 2, 18000m, 2, 3, 2024 },
                    { 3, 20000m, 3, 2, 2024 },
                    { 4, 16000m, 4, 1, 2024 },
                    { 5, 22000m, 5, 2, 2024 },
                    { 6, 19000m, 6, 1, 2024 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
