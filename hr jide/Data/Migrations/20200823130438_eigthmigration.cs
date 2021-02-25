using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_jide.Data.Migrations
{
    public partial class eigthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
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
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployementId = table.Column<int>(nullable: false),
                    Institute = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    GPA = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    JobTitlesId = table.Column<int>(nullable: false),
                    EmployementstatusId = table.Column<int>(nullable: true),
                    EmploymentStatusId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    JobCategoriesId = table.Column<int>(nullable: false),
                    CompanyBranchId = table.Column<int>(nullable: false),
                    JoinedDate = table.Column<DateTime>(nullable: false),
                    ContractStartDate = table.Column<DateTime>(nullable: false),
                    ContractEndDate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeJobs_CompanyBranch_CompanyBranchId",
                        column: x => x.CompanyBranchId,
                        principalTable: "CompanyBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobs_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobs_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobs_EmployementStatus_EmployementstatusId",
                        column: x => x.EmployementstatusId,
                        principalTable: "EmployementStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeJobs_JobCategories_JobCategoriesId",
                        column: x => x.JobCategoriesId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobs_JobTitles_JobTitlesId",
                        column: x => x.JobTitlesId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(nullable: false),
                    FluencyId = table.Column<int>(nullable: false),
                    CompetencyId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseId = table.Column<int>(nullable: false),
                    LicenseNumber = table.Column<int>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLicenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(nullable: false),
                    YearsOfExperience = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSubordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ReportingMethod = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSubordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSubordinates_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSupervisors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ReportingMethod = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSupervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSupervisors_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayFrequency",
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
                    table.PrimaryKey("PK_PayFrequency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
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
                    table.PrimaryKey("PK_Relationship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportingMethod",
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
                    table.PrimaryKey("PK_ReportingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(nullable: true),
                    TaxId = table.Column<int>(nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<long>(nullable: false),
                    Mobile = table.Column<long>(nullable: false),
                    WorkTelephone = table.Column<long>(nullable: false),
                    Fax = table.Column<long>(nullable: false),
                    WorkEmail = table.Column<string>(nullable: true),
                    OtherEmail = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City_or_state_or_province = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContactDetails_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeImmigrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    DocumentNumber = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    EligibleReviewDate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeImmigrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeImmigrations_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeImmigrations_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    payGradesId = table.Column<int>(nullable: true),
                    PayGradeId = table.Column<int>(nullable: false),
                    PayFrequencyId = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalaries_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalaries_PayFrequency_PayFrequencyId",
                        column: x => x.PayFrequencyId,
                        principalTable: "PayFrequency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalaries_PayGrades_payGradesId",
                        column: x => x.payGradesId,
                        principalTable: "PayGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDependants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RelationshipId = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDependants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDependants_Relationship_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmergencyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ReportingMethodId = table.Column<int>(nullable: true),
                    ReportMethodId = table.Column<int>(nullable: false),
                    HomeTelephone = table.Column<long>(nullable: false),
                    Mobile = table.Column<long>(nullable: false),
                    WorkTelephone = table.Column<long>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmergencyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEmergencyContacts_ReportingMethod_ReportingMethodId",
                        column: x => x.ReportingMethodId,
                        principalTable: "ReportingMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMemberships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    MembershipId = table.Column<int>(nullable: false),
                    ReportingMethodId = table.Column<int>(nullable: true),
                    ReportMethodId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMemberships_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMemberships_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMemberships_ReportingMethod_ReportingMethodId",
                        column: x => x.ReportingMethodId,
                        principalTable: "ReportingMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContactDetails_CountryId",
                table: "EmployeeContactDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependants_RelationshipId",
                table: "EmployeeDependants",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmergencyContacts_ReportingMethodId",
                table: "EmployeeEmergencyContacts",
                column: "ReportingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeImmigrations_CountryId",
                table: "EmployeeImmigrations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeImmigrations_DocumentTypeId",
                table: "EmployeeImmigrations",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_CompanyBranchId",
                table: "EmployeeJobs",
                column: "CompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_DepartmentId",
                table: "EmployeeJobs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_EmployeeId",
                table: "EmployeeJobs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_EmployementstatusId",
                table: "EmployeeJobs",
                column: "EmployementstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_JobCategoriesId",
                table: "EmployeeJobs",
                column: "JobCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobs_JobTitlesId",
                table: "EmployeeJobs",
                column: "JobTitlesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMemberships_EmployeeId",
                table: "EmployeeMemberships",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMemberships_MembershipId",
                table: "EmployeeMemberships",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMemberships_ReportingMethodId",
                table: "EmployeeMemberships",
                column: "ReportingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_PayFrequencyId",
                table: "EmployeeSalaries",
                column: "PayFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_payGradesId",
                table: "EmployeeSalaries",
                column: "payGradesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSubordinates_EmployeeId",
                table: "EmployeeSubordinates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSupervisors_EmployeeId",
                table: "EmployeeSupervisors",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContactDetails");

            migrationBuilder.DropTable(
                name: "EmployeeDependants");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "EmployeeEmergencyContacts");

            migrationBuilder.DropTable(
                name: "EmployeeImmigrations");

            migrationBuilder.DropTable(
                name: "EmployeeJobs");

            migrationBuilder.DropTable(
                name: "EmployeeLanguages");

            migrationBuilder.DropTable(
                name: "EmployeeLicenses");

            migrationBuilder.DropTable(
                name: "EmployeeMemberships");

            migrationBuilder.DropTable(
                name: "EmployeeSalaries");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "EmployeeSubordinates");

            migrationBuilder.DropTable(
                name: "EmployeeSupervisors");

            migrationBuilder.DropTable(
                name: "EmployeeWorkExperiences");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "ReportingMethod");

            migrationBuilder.DropTable(
                name: "PayFrequency");
        }
    }
}
