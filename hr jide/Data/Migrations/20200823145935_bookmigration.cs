using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_jide.Data.Migrations
{
    public partial class bookmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeSupervisors");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeSupervisors");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeSubordinates");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeSubordinates");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeMemberships");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeMemberships");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeLicenses");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeLicenses");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeImmigrations");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeImmigrations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "EmployeeContactDetails");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeWorkExperiences",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeWorkExperiences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeWorkExperiences",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeWorkExperiences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeSupervisors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeSupervisors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeSupervisors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeSupervisors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeSubordinates",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeSubordinates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeSubordinates",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeSubordinates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeSkills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeSkills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeSalaries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeSalaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeSalaries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeSalaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeMemberships",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeMemberships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeMemberships",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeMemberships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeLicenses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeLicenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeLicenses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeLicenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeLanguages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeLanguages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeLanguages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeLanguages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeJobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeJobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeImmigrations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeImmigrations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeImmigrations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeImmigrations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeEmergencyContacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeEmergencyContacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeEmergencyContacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeEmergencyContacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeEducations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeEducations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeEducations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeEducations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeDependants",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeDependants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeDependants",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeDependants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EmployeeContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EmployeeContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Department",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Department",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeSupervisors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeSupervisors");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeSupervisors");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeSupervisors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeSubordinates");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeSubordinates");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeSubordinates");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeSubordinates");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeMemberships");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeMemberships");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeMemberships");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeMemberships");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeLicenses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeLicenses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeLicenses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeLicenses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeImmigrations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeImmigrations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeImmigrations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeImmigrations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeEmergencyContacts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeDependants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Department");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeWorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeWorkExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeSupervisors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeSupervisors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeSubordinates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeSubordinates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeSkills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeSkills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeSalaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeSalaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeMemberships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeMemberships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeLicenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeLicenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeLanguages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeLanguages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeImmigrations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeImmigrations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeEmergencyContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeEmergencyContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeEducations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeEducations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeDependants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeDependants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EmployeeContactDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "EmployeeContactDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
