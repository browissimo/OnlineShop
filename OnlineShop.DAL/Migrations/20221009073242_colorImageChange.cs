using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DAL.Migrations
{
    public partial class colorImageChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImages_Items_ItemId",
                table: "ItemImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemImages",
                table: "ItemImages");

            migrationBuilder.RenameTable(
                name: "ItemImages",
                newName: "ItemImage");

            migrationBuilder.RenameIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImage",
                newName: "IX_ItemImage_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemImage",
                table: "ItemImage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ItemColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    RGB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ModelSize = table.Column<int>(type: "int", nullable: false),
                    ModelCharacteristics = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemColors_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemColors_ColorId",
                table: "ItemColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemColors_ItemId",
                table: "ItemColors",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Items_ItemId",
                table: "ItemImage",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_Items_ItemId",
                table: "ItemImage");

            migrationBuilder.DropTable(
                name: "ItemColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemImage",
                table: "ItemImage");

            migrationBuilder.RenameTable(
                name: "ItemImage",
                newName: "ItemImages");

            migrationBuilder.RenameIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImages",
                newName: "IX_ItemImages_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemImages",
                table: "ItemImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImages_Items_ItemId",
                table: "ItemImages",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
