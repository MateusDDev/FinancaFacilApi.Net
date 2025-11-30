using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.FinancaFacil.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_renda",
                columns: table => new
                {
                    IdRenda = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CdRenda = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TpRenda = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VlRenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_renda", x => x.IdRenda);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NmUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_renda");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
