using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Liquors.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alcohols",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcohols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vintages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vintages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Winery = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wine_Alcohols_Id",
                        column: x => x.Id,
                        principalTable: "Alcohols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlcoholVintage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlcoholId = table.Column<int>(nullable: false),
                    VintageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholVintage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlcoholVintage_Alcohols_AlcoholId",
                        column: x => x.AlcoholId,
                        principalTable: "Alcohols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlcoholVintage_Vintages_VintageId",
                        column: x => x.VintageId,
                        principalTable: "Vintages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholVintage_AlcoholId",
                table: "AlcoholVintage",
                column: "AlcoholId");

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholVintage_VintageId",
                table: "AlcoholVintage",
                column: "VintageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlcoholVintage");

            migrationBuilder.DropTable(
                name: "Wine");

            migrationBuilder.DropTable(
                name: "Vintages");

            migrationBuilder.DropTable(
                name: "Alcohols");
        }
    }
}
