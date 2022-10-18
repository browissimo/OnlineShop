using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DAL.Migrations
{
    public partial class itemSize_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelSize",
                table: "ItemColors",
                newName: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemColors_SizeID",
                table: "ItemColors",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColors_Size_SizeID",
                table: "ItemColors",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemColors_Size_SizeID",
                table: "ItemColors");

            migrationBuilder.DropIndex(
                name: "IX_ItemColors_SizeID",
                table: "ItemColors");

            migrationBuilder.RenameColumn(
                name: "SizeID",
                table: "ItemColors",
                newName: "ModelSize");
        }
    }
}
