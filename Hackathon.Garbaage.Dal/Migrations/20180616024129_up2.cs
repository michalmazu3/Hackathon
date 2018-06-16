using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackathon.Garbage.Dal.Migrations
{
    public partial class up2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoEntity_Orders_OrderId",
                table: "PhotoEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoEntity_Ratings_RatingId",
                table: "PhotoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoEntity",
                table: "PhotoEntity");

            migrationBuilder.RenameTable(
                name: "PhotoEntity",
                newName: "Photos");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoEntity_RatingId",
                table: "Photos",
                newName: "IX_Photos_RatingId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoEntity_OrderId",
                table: "Photos",
                newName: "IX_Photos_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Orders_OrderId",
                table: "Photos",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Ratings_RatingId",
                table: "Photos",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Orders_OrderId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Ratings_RatingId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "PhotoEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_RatingId",
                table: "PhotoEntity",
                newName: "IX_PhotoEntity_RatingId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_OrderId",
                table: "PhotoEntity",
                newName: "IX_PhotoEntity_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoEntity",
                table: "PhotoEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoEntity_Orders_OrderId",
                table: "PhotoEntity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoEntity_Ratings_RatingId",
                table: "PhotoEntity",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
