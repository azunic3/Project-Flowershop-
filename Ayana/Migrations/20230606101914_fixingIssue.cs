using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class fixingIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetUsers_Id",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
