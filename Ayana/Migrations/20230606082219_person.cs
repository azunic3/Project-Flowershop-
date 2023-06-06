using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ayana.Migrations
{
    public partial class person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Person",
              columns: table => new
              {
                  FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
              name: "Person",
              columns: table => new
              {

                  FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),

              });
        }
    }
}
