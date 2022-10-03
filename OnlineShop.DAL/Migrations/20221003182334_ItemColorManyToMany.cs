using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DAL.Migrations
{
    public partial class ItemColorManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Colors_ColorId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ColorId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "rgb",
                table: "Colors",
                newName: "RGB");

            migrationBuilder.CreateTable(
                name: "ColorItem",
                columns: table => new
                {
                    ColorsId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorItem", x => new { x.ColorsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ColorItem_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorItem_ItemsId",
                table: "ColorItem",
                column: "ItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorItem");

            migrationBuilder.RenameColumn(
                name: "RGB",
                table: "Colors",
                newName: "rgb");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ColorId",
                table: "Items",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Colors_ColorId",
                table: "Items",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");
        }
    }
}
