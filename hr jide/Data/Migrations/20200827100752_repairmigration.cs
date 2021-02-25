using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_jide.Data.Migrations
{
    public partial class repairmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDependants_Relationship_RelationshipId",
                table: "EmployeeDependants");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEmergencyContacts_ReportingMethod_ReportingMethodId",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobs_Employee_EmployeeId",
                table: "EmployeeJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMemberships_Employee_EmployeeId",
                table: "EmployeeMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_Employee_EmployeeId",
                table: "EmployeeSalaries");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSubordinates_Employee_EmployeeId",
                table: "EmployeeSubordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSupervisors_Employee_EmployeeId",
                table: "EmployeeSupervisors");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSupervisors_EmployeeId",
                table: "EmployeeSupervisors");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSubordinates_EmployeeId",
                table: "EmployeeSubordinates");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalaries");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeMemberships_EmployeeId",
                table: "EmployeeMemberships");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeJobs_EmployeeId",
                table: "EmployeeJobs");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeEmergencyContacts_ReportingMethodId",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDependants_RelationshipId",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "CompetencyId",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "FluencyId",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "ReportMethodId",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "ReportingMethodId",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "EmployementId",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "RelationshipId",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "NumberOfEmployees",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "EmployeeContactDetails");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeWorkExperiences",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeSupervisors",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeSubordinates",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeSkills",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeSalaries",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeMemberships",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeLicenses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Competency",
                table: "EmployeeLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeLanguages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fluency",
                table: "EmployeeLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "EmployeeLanguages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeJobs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeImmigrations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeEmergencyContacts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Relationship",
                table: "EmployeeEmergencyContacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeEducations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "EmployeeEducations",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeDependants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Relationship",
                table: "EmployeeDependants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeContactDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeLicenses");

            migrationBuilder.DropColumn(
                name: "Competency",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "Fluency",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "Relationship",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "Relationship",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeContactDetails");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeSupervisors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeSubordinates",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeSalaries",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeMemberships",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "EmployeeLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeJobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeImmigrations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeEmergencyContacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportMethodId",
                table: "EmployeeEmergencyContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportingMethodId",
                table: "EmployeeEmergencyContacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployementId",
                table: "EmployeeEducations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeDependants",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationshipId",
                table: "EmployeeDependants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEmployees",
                table: "EmployeeContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "EmployeeContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "EmployeeContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "EmployeeContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Relationship",
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
                    table.PrimaryKey("PK_Relationship", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSupervisors_EmployeeId",
                table: "EmployeeSupervisors",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSubordinates_EmployeeId",
                table: "EmployeeSubordinates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMemberships_EmployeeId",
                table: "EmployeeMemberships",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_EmployeeId",
                table: "EmployeeJobs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmergencyContacts_ReportingMethodId",
                table: "EmployeeEmergencyContacts",
                column: "ReportingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependants_RelationshipId",
                table: "EmployeeDependants",
                column: "RelationshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDependants_Relationship_RelationshipId",
                table: "EmployeeDependants",
                column: "RelationshipId",
                principalTable: "Relationship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEmergencyContacts_ReportingMethod_ReportingMethodId",
                table: "EmployeeEmergencyContacts",
                column: "ReportingMethodId",
                principalTable: "ReportingMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobs_Employee_EmployeeId",
                table: "EmployeeJobs",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMemberships_Employee_EmployeeId",
                table: "EmployeeMemberships",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_Employee_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSubordinates_Employee_EmployeeId",
                table: "EmployeeSubordinates",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSupervisors_Employee_EmployeeId",
                table: "EmployeeSupervisors",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
