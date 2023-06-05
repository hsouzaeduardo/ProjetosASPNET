using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo07.Migrations
{
    public partial class colunaNumero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Enderecos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Enderecos");
        }
    }
}
