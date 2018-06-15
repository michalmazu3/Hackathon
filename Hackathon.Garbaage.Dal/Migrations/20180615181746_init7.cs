using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Garbage.Dal.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FieldId",
                table: "Cordinates");

            migrationBuilder.AddForeignKey(
                name: "FK_Cordinates_Fields_FieldId",
                table: "Cordinates",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cordinates_Fields_FieldId",
                table: "Cordinates");

            migrationBuilder.AddForeignKey(
                name: "FieldId",
                table: "Cordinates",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
