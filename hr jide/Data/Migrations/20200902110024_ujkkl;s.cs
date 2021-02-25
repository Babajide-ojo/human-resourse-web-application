using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_jide.Data.Migrations
{
    public partial class ujkkls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fluency",
                table: "EmployeeLanguages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FluencyId",
                table: "EmployeeLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Competency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
