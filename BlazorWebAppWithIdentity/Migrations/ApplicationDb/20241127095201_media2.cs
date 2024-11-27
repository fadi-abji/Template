using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebAppWithIdentity.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class media2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternateText",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaTypeId",
                table: "Media",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalFilename",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaTypeId",
                table: "Media",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MediaType_MediaTypeId",
                table: "Media",
                column: "MediaTypeId",
                principalTable: "MediaType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_MediaType_MediaTypeId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropIndex(
                name: "IX_Media_MediaTypeId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "AlternateText",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MediaTypeId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "OriginalFilename",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Media");
        }
    }
}
