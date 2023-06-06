using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class DropUnnecessaryForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
             name: "FK_Customers_AspNetUsers_Id",
             table: "Customers");
            migrationBuilder.DropForeignKey(
               name: "FK_Employees_AspNetUsers_Id",
               table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
             name: "FK_Customers_AspNetUsers_Id",
             table: "Customers");
            migrationBuilder.DropForeignKey(
               name: "FK_Employees_AspNetUsers_Id",
               table: "Employees");
        }
    }
}
