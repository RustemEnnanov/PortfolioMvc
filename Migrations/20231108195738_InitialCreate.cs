using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSecondVersion.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lenguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePortfolio",
                columns: table => new
                {
                    LanguagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfoliosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePortfolio", x => new { x.LanguagesId, x.PortfoliosId });
                    table.ForeignKey(
                        name: "FK_LanguagePortfolio_Lenguages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Lenguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePortfolio_Portfolios_PortfoliosId",
                        column: x => x.PortfoliosId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePortfolio_PortfoliosId",
                table: "LanguagePortfolio",
                column: "PortfoliosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePortfolio");

            migrationBuilder.DropTable(
                name: "Lenguages");

            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
