using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DAL.Migrations
{
    public partial class sizesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSize",
                columns: table => new
                {
                    SizesId = table.Column<int>(type: "int", nullable: false),
                    itemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSize", x => new { x.SizesId, x.itemsId });
                    table.ForeignKey(
                        name: "FK_ItemSize_Items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSize_Size_SizesId",
                        column: x => x.SizesId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSize_itemsId",
                table: "ItemSize",
                column: "itemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSize");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
