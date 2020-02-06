using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Bunny.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TelefonNumber = table.Column<long>(nullable: false),
                    DateOfBirdh = table.Column<DateTime>(nullable: false),
                    AllSalePrice = table.Column<double>(nullable: false),
                    TotalVisits = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    NumberOfDrunkGlasses = table.Column<int>(nullable: false),
                    GlassesOfShares = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "KartSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KartName = table.Column<string>(nullable: true),
                    KartNumber = table.Column<long>(nullable: false),
                    NameCustomer = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KartSales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitCustomers",
                columns: table => new
                {
                    VisitId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateVisit = table.Column<string>(nullable: true),
                    VisitSalePrice = table.Column<double>(nullable: false),
                    VisitNumberOfDrunkGlasses = table.Column<int>(nullable: false),
                    NameCustomer = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitCustomers", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_VisitCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KartSales_CustomerId",
                table: "KartSales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitCustomers_CustomerId",
                table: "VisitCustomers",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KartSales");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VisitCustomers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
