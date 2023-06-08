using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "ProductOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountID",
                table: "DtoRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "DtoRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "DtoRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductOrderID",
                table: "DtoRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSalesID",
                table: "DtoRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DtoRequests_DiscountID",
                table: "DtoRequests",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_DtoRequests_OrderID",
                table: "DtoRequests",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_DtoRequests_ProductID",
                table: "DtoRequests",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_DtoRequests_ProductOrderID",
                table: "DtoRequests",
                column: "ProductOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_DtoRequests_ProductSalesID",
                table: "DtoRequests",
                column: "ProductSalesID");

            migrationBuilder.AddForeignKey(
                name: "FK_DtoRequests_Discounts_DiscountID",
                table: "DtoRequests",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DtoRequests_Orders_OrderID",
                table: "DtoRequests",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DtoRequests_ProductOrders_ProductOrderID",
                table: "DtoRequests",
                column: "ProductOrderID",
                principalTable: "ProductOrders",
                principalColumn: "ProductOrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DtoRequests_Products_ProductID",
                table: "DtoRequests",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DtoRequests_ProductSales_ProductSalesID",
                table: "DtoRequests",
                column: "ProductSalesID",
                principalTable: "ProductSales",
                principalColumn: "ProductSalesID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DtoRequests_Discounts_DiscountID",
                table: "DtoRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_DtoRequests_Orders_OrderID",
                table: "DtoRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_DtoRequests_ProductOrders_ProductOrderID",
                table: "DtoRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_DtoRequests_Products_ProductID",
                table: "DtoRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_DtoRequests_ProductSales_ProductSalesID",
                table: "DtoRequests");

            migrationBuilder.DropIndex(
                name: "IX_DtoRequests_DiscountID",
                table: "DtoRequests");

            migrationBuilder.DropIndex(
                name: "IX_DtoRequests_OrderID",
                table: "DtoRequests");

            migrationBuilder.DropIndex(
                name: "IX_DtoRequests_ProductID",
                table: "DtoRequests");

            migrationBuilder.DropIndex(
                name: "IX_DtoRequests_ProductOrderID",
                table: "DtoRequests");

            migrationBuilder.DropIndex(
                name: "IX_DtoRequests_ProductSalesID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "DiscountID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "ProductOrderID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "ProductSalesID",
                table: "DtoRequests");
        }
    }
}
