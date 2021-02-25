using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_jide.Data.Migrations
{
    public partial class employ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employ_AspNetUsers_IdentityUserId",
                table: "Employ");

            migrationBuilder.DropIndex(
                name: "IX_Employ_IdentityUserId",
                table: "Employ");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Employ");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Employ",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employ");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Employ",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employ_IdentityUserId",
                table: "Employ",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employ_AspNetUsers_IdentityUserId",
                table: "Employ",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
