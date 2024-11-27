using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebAppWithIdentity.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class moviemedianavproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieMedia_Media_MediaUid1",
                table: "MovieMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieMedia",
                table: "MovieMedia");

            migrationBuilder.DropIndex(
                name: "IX_MovieMedia_MediaUid1",
                table: "MovieMedia");

            migrationBuilder.DropColumn(
                name: "MediaUid1",
                table: "MovieMedia");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MovieMedia",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieMedia",
                table: "MovieMedia",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMedia_MediaUid",
                table: "MovieMedia",
                column: "MediaUid");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieMedia_Media_MediaUid",
                table: "MovieMedia",
                column: "MediaUid",
                principalTable: "Media",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieMedia_Media_MediaUid",
                table: "MovieMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieMedia",
                table: "MovieMedia");

            migrationBuilder.DropIndex(
                name: "IX_MovieMedia_MediaUid",
                table: "MovieMedia");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieMedia");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaUid1",
                table: "MovieMedia",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieMedia",
                table: "MovieMedia",
                column: "MediaUid");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMedia_MediaUid1",
                table: "MovieMedia",
                column: "MediaUid1");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieMedia_Media_MediaUid1",
                table: "MovieMedia",
                column: "MediaUid1",
                principalTable: "Media",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
