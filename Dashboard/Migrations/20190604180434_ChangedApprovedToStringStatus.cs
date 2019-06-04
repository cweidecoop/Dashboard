using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Migrations
{
    public partial class ChangedApprovedToStringStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "ParaLogs");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ParaLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ParaLogs");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "ParaLogs",
                nullable: false,
                defaultValue: false);
        }
    }
}
