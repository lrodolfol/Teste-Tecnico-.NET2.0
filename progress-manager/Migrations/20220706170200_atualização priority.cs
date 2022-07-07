using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace progress_manager.Migrations
{
    public partial class atualizaçãopriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPriority",
                table: "Progress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPriority",
                table: "Progress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
