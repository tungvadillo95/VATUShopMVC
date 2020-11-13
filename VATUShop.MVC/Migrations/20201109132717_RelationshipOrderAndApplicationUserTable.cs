using Microsoft.EntityFrameworkCore.Migrations;

namespace VATUShop.MVC.Migrations
{
    public partial class RelationshipOrderAndApplicationUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountCustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountCustomerId",
                table: "Orders",
                column: "AccountCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AccountCustomerId",
                table: "Orders",
                column: "AccountCustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AccountCustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountCustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountCustomerId",
                table: "Orders");
        }
    }
}
