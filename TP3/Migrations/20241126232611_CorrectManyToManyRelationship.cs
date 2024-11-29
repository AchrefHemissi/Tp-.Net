using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class CorrectManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Customers_CustomersCustomerid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CustomersCustomerid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CustomersCustomerid",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "Movies",
                newName: "GenreId");

            migrationBuilder.CreateTable(
                name: "CustomerMovie",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MovieId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMovie", x => new { x.CustomerId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CustomerMovie_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovie_MovieId",
                table: "CustomerMovie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "CustomerMovie");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Movies",
                newName: "genre_id");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomersCustomerid",
                table: "Movies",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CustomersCustomerid",
                table: "Movies",
                column: "CustomersCustomerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Customers_CustomersCustomerid",
                table: "Movies",
                column: "CustomersCustomerid",
                principalTable: "Customers",
                principalColumn: "Customerid");
        }
    }
}
