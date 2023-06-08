using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class productSalesFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSales_ProductSalesID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSalesID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductSalesID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProductSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_ProductID",
                table: "ProductSales",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSales_Products_ProductID",
                table: "ProductSales",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSales_Products_ProductID",
                table: "ProductSales");

            migrationBuilder.DropIndex(
                name: "IX_ProductSales_ProductID",
                table: "ProductSales");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProductSales");

            migrationBuilder.AddColumn<int>(
                name: "ProductSalesID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSalesID",
                table: "Products",
                column: "ProductSalesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSales_ProductSalesID",
                table: "Products",
                column: "ProductSalesID",
                principalTable: "ProductSales",
                principalColumn: "ProductSalesID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
