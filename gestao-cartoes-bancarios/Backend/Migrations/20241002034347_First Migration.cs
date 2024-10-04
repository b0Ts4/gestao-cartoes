using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestao_cartoes_bancarios.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalhesCartao",
                columns: table => new
                {
                    DetalhesCartaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTitularCartao = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    numeroCartao = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    DataDevalidade = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CodigoDeSegurança = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhesCartao", x => x.DetalhesCartaoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalhesCartao");
        }
    }
}
