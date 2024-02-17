using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microsservice_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    celular = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    criado_por = table.Column<Guid>(type: "uuid", nullable: false),
                    dt_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modificado_por = table.Column<Guid>(type: "uuid", nullable: true),
                    dt_modificacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    tp_status = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_usuarios");
        }
    }
}
