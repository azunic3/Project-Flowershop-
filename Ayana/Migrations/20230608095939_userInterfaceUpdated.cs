using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class userInterfaceUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DtoRequests_Discounts_DiscountID",
                table: "DtoRequests");

            migrationBuilder.DropIndex(
                name: "IX_DtoRequests_DiscountID",
                table: "DtoRequests");

            migrationBuilder.DropColumn(
                name: "DiscountID",
                table: "DtoRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountID",
                table: "DtoRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DtoRequests_DiscountID",
                table: "DtoRequests",
                column: "DiscountID");

            migrationBuilder.AddForeignKey(
                name: "FK_DtoRequests_Discounts_DiscountID",
                table: "DtoRequests",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
