using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace todo_manager.Migrations
{
    public partial class DBInitials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserStory = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPriority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todo_Priority_IdPriority",
                        column: x => x.IdPriority,
                        principalTable: "Priority",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "baixo" });

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "medio" });

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "alto" });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_IdPriority",
                table: "Todo",
                column: "IdPriority");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "Priority");
        }
    }
}
