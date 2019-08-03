using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Perque.Data.Migrations
{
    public partial class LookupTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUpTypes",
                schema: "Infra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUps",
                schema: "Infra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LookUpTypeId = table.Column<int>(nullable: false),
                    UpLookUpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUps_LookUpTypes_LookUpTypeId",
                        column: x => x.LookUpTypeId,
                        principalSchema: "Infra",
                        principalTable: "LookUpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookUps_LookUps_UpLookUpId",
                        column: x => x.UpLookUpId,
                        principalSchema: "Infra",
                        principalTable: "LookUps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUps_LookUpTypeId",
                schema: "Infra",
                table: "LookUps",
                column: "LookUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUps_UpLookUpId",
                schema: "Infra",
                table: "LookUps",
                column: "UpLookUpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUps",
                schema: "Infra");

            migrationBuilder.DropTable(
                name: "LookUpTypes",
                schema: "Infra");
        }
    }
}
