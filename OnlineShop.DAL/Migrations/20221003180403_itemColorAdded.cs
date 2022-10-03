using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DAL.Migrations
{
    public partial class itemColorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Color_ColorId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Colors_ColorId",
                table: "Items",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Colors_ColorId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Color_ColorId",
                table: "Items",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");
        }
    }
}
