using Microsoft.EntityFrameworkCore.Migrations;

namespace VATUShop.MVC.Migrations
{
    public partial class RelationshipOrderAndCustomerAnonymousTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerAnonymousId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerAnonymousId",
                table: "Orders",
                column: "CustomerAnonymousId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerAnonymouses_CustomerAnonymousId",
                table: "Orders",
                column: "CustomerAnonymousId",
                principalTable: "CustomerAnonymouses",
                principalColumn: "CustomerAnonymousId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerAnonymouses_CustomerAnonymousId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerAnonymousId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerAnonymousId",
                table: "Orders");
        }
    }
}
