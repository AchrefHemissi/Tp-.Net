using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenresId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenresId",
                table: "Movies");

            migrationBuilder.AddColumn<Guid>(
                name: "GenresId1",
                table: "Movies",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Genres",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { new Guid("79e6f638-d7e7-4f63-8365-f172cb925381"), "GenreFromJsonFile2" },
                    { new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8285"), "GenreFromJsonFile1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenresId1",
                table: "Movies",
                column: "GenresId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenresId1",
                table: "Movies",
                column: "GenresId1",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenresId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenresId1",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("79e6f638-d7e7-4f63-8365-f172cb925381"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8285"));

            migrationBuilder.DropColumn(
                name: "GenresId1",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenresId",
                table: "Movies",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenresId",
                table: "Movies",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
