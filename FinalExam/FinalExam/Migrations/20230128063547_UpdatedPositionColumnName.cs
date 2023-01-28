using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalExam.Migrations
{
    public partial class UpdatedPositionColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Positon",
                table: "TeamMembers",
                newName: "Position");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "TeamMembers",
                newName: "Positon");
        }
    }
}
