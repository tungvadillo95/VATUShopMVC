using Microsoft.EntityFrameworkCore.Migrations;

namespace VATUShop.MVC.Migrations
{
    public partial class EditRelationshipOrderAndCustomerAnonymousTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CustomerAnonymouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAnonymouses_OrderId",
                table: "CustomerAnonymouses",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAnonymouses_Orders_OrderId",
                table: "CustomerAnonymouses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAnonymouses_Orders_OrderId",
                table: "CustomerAnonymouses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAnonymouses_OrderId",
                table: "CustomerAnonymouses");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CustomerAnonymouses");

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
    }
}
