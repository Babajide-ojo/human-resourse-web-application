using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_jide.Data.Migrations
{
    public partial class jikldnm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Competency",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "Fluency",
                table: "EmployeeLanguages");

            migrationBuilder.AddColumn<int>(
                name: "CompetencyId",
                table: "EmployeeLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FluencyId",
                table: "EmployeeLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Competency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguages_CompetencyId",
                table: "EmployeeLanguages",
                column: "CompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguages_FluencyId",
                table: "EmployeeLanguages",
                column: "FluencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLanguages_Competency_CompetencyId",
                table: "EmployeeLanguages",
                column: "CompetencyId",
                principalTable: "Competency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLanguages_Fluency_FluencyId",
                table: "EmployeeLanguages",
                column: "FluencyId",
                principalTable: "Fluency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLanguages_Competency_CompetencyId",
                table: "EmployeeLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLanguages_Fluency_FluencyId",
                table: "EmployeeLanguages");

            migrationBuilder.DropTable(
                name: "Competency");

            migrationBuilder.DropTable(
                name: "Fluency");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeLanguages_CompetencyId",
                table: "EmployeeLanguages");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeLanguages_FluencyId",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "CompetencyId",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "FluencyId",
                table: "EmployeeLanguages");

            migrationBuilder.AddColumn<string>(
                name: "Competency",
                table: "EmployeeLanguages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fluency",
                table: "EmployeeLanguages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
