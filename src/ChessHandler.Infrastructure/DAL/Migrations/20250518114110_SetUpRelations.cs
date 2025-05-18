using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessHandler.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SetUpRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_BlackId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WhiteId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_BlackId",
                table: "Games",
                column: "BlackId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WhiteId",
                table: "Games",
                column: "WhiteId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_BlackId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WhiteId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_BlackId",
                table: "Games",
                column: "BlackId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WhiteId",
                table: "Games",
                column: "WhiteId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
