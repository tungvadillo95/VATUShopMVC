using Microsoft.EntityFrameworkCore.Migrations;

namespace VATUShop.MVC.Migrations
{
    public partial class AddColEmailToCustomerAnonymousTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerAnonymouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerAnonymouses");
        }
    }
}
