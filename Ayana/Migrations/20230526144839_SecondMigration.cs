using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerID",
                table: "Subscriptions",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PaymentID",
                table: "Subscriptions",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeID",
                table: "Reports",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderID",
                table: "ProductOrders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductID",
                table: "ProductOrders",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DiscountID",
                table: "Payments",
                column: "DiscountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Discounts_DiscountID",
                table: "Payments",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Orders_OrderID",
                table: "ProductOrders",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Products_ProductID",
                table: "ProductOrders",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Employees_EmployeeID",
                table: "Reports",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Customers_CustomerID",
                table: "Subscriptions",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Payments_PaymentID",
                table: "Subscriptions",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Discounts_DiscountID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Orders_OrderID",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Products_ProductID",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Employees_EmployeeID",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Customers_CustomerID",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Payments_PaymentID",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_CustomerID",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_PaymentID",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Reports_EmployeeID",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_OrderID",
                table: "ProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_ProductID",
                table: "ProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DiscountID",
                table: "Payments");
        }
    }
}
