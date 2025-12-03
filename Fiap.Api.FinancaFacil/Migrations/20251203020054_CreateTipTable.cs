using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.FinancaFacil.Migrations
{
    /// <inheritdoc />
    public partial class CreateTipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_despesa",
                columns: table => new
                {
                    IdDespesa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_despesa", x => x.IdDespesa);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_renda_IdUsuario",
                table: "tb_renda",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_renda_tb_usuario_IdUsuario",
                table: "tb_renda",
                column: "IdUsuario",
                principalTable: "tb_usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_renda_tb_usuario_IdUsuario",
                table: "tb_renda");

            migrationBuilder.DropTable(
                name: "tb_despesa");

            migrationBuilder.DropIndex(
                name: "IX_tb_renda_IdUsuario",
                table: "tb_renda");
        }
    }
}
