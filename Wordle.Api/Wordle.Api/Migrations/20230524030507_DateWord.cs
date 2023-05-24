using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class DateWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateWord",
                columns: table => new
                {
                    DateWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateWord", x => x.DateWordId);
                    table.ForeignKey(
                        name: "FK_DateWord_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    PlayerGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    DateWordId = table.Column<int>(type: "int", nullable: true),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    DurationInSeconds = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WasGameWon = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => x.PlayerGameId);
                    table.ForeignKey(
                        name: "FK_PlayerGame_DateWord_DateWordId",
                        column: x => x.DateWordId,
                        principalTable: "DateWord",
                        principalColumn: "DateWordId");
                    table.ForeignKey(
                        name: "FK_PlayerGame_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateWord_WordId",
                table: "DateWord",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_DateWordId",
                table: "PlayerGame",
                column: "DateWordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_PlayerId",
                table: "PlayerGame",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_WordId",
                table: "PlayerGame",
                column: "WordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.DropTable(
                name: "DateWord");
        }
    }
}
