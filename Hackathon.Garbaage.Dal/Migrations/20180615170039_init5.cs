using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Garbage.Dal.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cordinates_Fields_FieldId",
                table: "Cordinates");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Cordinates");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Cordinates",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Cordinates",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude ",
                table: "Cordinates",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FieldId",
                table: "Cordinates",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FieldId",
                table: "Cordinates");

            migrationBuilder.DropColumn(
                name: "Longitude ",
                table: "Cordinates");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Cordinates",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Cordinates",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Cordinates",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cordinates_Fields_FieldId",
                table: "Cordinates",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
