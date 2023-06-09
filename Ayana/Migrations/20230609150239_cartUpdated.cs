using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class cartUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "DtoRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DtoRequests_CartID",
                table: "DtoRequests",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_DtoRequests_Carts_CartID",
                table: "DtoRequests",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DtoRequests_Carts_CartID",
                table: "DtoRequests");

            migrationBuilder.DropIndex(
                name: "IX_DtoRequests_CartID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Carts");
        }
    }
}
