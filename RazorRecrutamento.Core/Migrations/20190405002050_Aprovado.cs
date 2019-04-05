using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorRecrutamento.Core.Migrations
{
    public partial class Aprovado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprovado",
                table: "Candidatos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovado",
                table: "Candidatos");
        }
    }
}
