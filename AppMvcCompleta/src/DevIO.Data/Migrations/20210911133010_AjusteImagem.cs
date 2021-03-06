using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class AjusteImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                schema: "dbo",
                table: "Produto",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                schema: "dbo",
                table: "Produto",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);
        }
    }
}
