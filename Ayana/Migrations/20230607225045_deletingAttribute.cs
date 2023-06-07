using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class deletingAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Discounts_DiscountID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsPaymentValid",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BankAccount",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Discounts_DiscountID",
                table: "Payments",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Discounts_DiscountID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentValid",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankAccount",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Discounts_DiscountID",
                table: "Payments",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
