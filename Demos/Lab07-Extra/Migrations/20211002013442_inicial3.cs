using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab07_Extra.Migrations
{
    public partial class inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtInclusao",
                table: "TB_PESSOA",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TB_Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Curso", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Curso");

            migrationBuilder.DropColumn(
                name: "DtInclusao",
                table: "TB_PESSOA");
        }
    }
}
