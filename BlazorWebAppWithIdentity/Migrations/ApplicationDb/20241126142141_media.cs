using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebAppWithIdentity.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class media : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "MovieMedia",
                columns: table => new
                {
                    MediaUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MediaUid1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMedia", x => x.MediaUid);
                    table.ForeignKey(
                        name: "FK_MovieMedia_Media_MediaUid1",
                        column: x => x.MediaUid1,
                        principalTable: "Media",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMedia_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieMedia_MediaUid1",
                table: "MovieMedia",
                column: "MediaUid1");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMedia_MovieId",
                table: "MovieMedia",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieMedia");

            migrationBuilder.DropTable(
                name: "Media");
        }
    }
}
