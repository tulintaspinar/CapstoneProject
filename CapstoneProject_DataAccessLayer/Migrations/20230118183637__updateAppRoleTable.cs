using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneProject_DataAccessLayer.Migrations
{
    public partial class _updateAppRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleDescription",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleDescription",
                table: "AspNetRoles");
        }
    }
}
