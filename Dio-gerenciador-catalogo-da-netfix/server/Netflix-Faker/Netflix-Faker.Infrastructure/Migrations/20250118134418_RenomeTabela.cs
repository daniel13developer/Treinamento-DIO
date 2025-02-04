using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflix_Faker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenomeTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimentacoes",
                table: "Movimentacoes");

            migrationBuilder.RenameTable(
                name: "Movimentacoes",
                newName: "Catalogo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogo",
                table: "Catalogo",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogo",
                table: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Catalogo",
                newName: "Movimentacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimentacoes",
                table: "Movimentacoes",
                column: "Id");
        }
    }
}
