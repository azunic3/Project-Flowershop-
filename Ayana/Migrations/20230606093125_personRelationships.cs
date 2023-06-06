using Microsoft.EntityFrameworkCore.Migrations;

namespace Ayana.Migrations
{
    public partial class personRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "Id",
              table: "Person",
              type: "nvarchar(450)",
              nullable: false,
              defaultValue: "");
            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_AspNetUsers_Id",
                table: "Person",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Customers_CustomerID",
                table: "Subscriptions");
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports");
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");
            migrationBuilder.AddPrimaryKey(
               name: "PK_Employees",
               table: "Employees",
               column: "Id");
migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Person_Id",
                table: "Customers",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Person_Id",
                table: "Employees",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
            name: "FK_Orders_Customers_CustomerId",
            table: "Orders",
            column: "CustomerId",
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        

            


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "Id",
               table: "Person",
               type: "nvarchar(450)",
               nullable: false,
               defaultValue: "");
            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_AspNetUsers_Id",
                table: "Person",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Customers_CustomerID",
                table: "Subscriptions");
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports");
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");
            migrationBuilder.AddPrimaryKey(
               name: "PK_Employees",
               table: "Employees",
               column: "Id");
 migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Person_Id",
                table: "Customers",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Person_Id",
                table: "Employees",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
            name: "FK_Orders_Customers_CustomerId",
            table: "Orders",
            column: "CustomerId",
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_Id",
                table: "Customers");
            migrationBuilder.DropForeignKey(
               name: "FK_Employees_AspNetUsers_Id",
               table: "Employees");
        }
    }
}
