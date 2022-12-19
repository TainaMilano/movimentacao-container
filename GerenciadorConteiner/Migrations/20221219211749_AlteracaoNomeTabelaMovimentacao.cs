using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoNomeTabelaMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_CONTEINERS_ConteinerId",
                table: "Movimentacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimentacoes",
                table: "Movimentacoes");

            migrationBuilder.RenameTable(
                name: "Movimentacoes",
                newName: "MOVIMENTACOES");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_ConteinerId",
                table: "MOVIMENTACOES",
                newName: "IX_MOVIMENTACOES_ConteinerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MOVIMENTACOES",
                table: "MOVIMENTACOES",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MOVIMENTACOES_CONTEINERS_ConteinerId",
                table: "MOVIMENTACOES",
                column: "ConteinerId",
                principalTable: "CONTEINERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MOVIMENTACOES_CONTEINERS_ConteinerId",
                table: "MOVIMENTACOES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MOVIMENTACOES",
                table: "MOVIMENTACOES");

            migrationBuilder.RenameTable(
                name: "MOVIMENTACOES",
                newName: "Movimentacoes");

            migrationBuilder.RenameIndex(
                name: "IX_MOVIMENTACOES_ConteinerId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_ConteinerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimentacoes",
                table: "Movimentacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_CONTEINERS_ConteinerId",
                table: "Movimentacoes",
                column: "ConteinerId",
                principalTable: "CONTEINERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
