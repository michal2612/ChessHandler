using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessHandler.Infrastructure.DAL
{
    /// <inheritdoc />
    public partial class AddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IDX_GamePlayer_Name",
                table: "Players",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IDX_GamePlayer_Name",
                table: "Players");
        }
    }
}
