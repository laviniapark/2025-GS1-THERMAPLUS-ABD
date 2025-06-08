using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Therma_Plus_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class Substituir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_REGIOES",
                columns: table => new
                {
                    id_regiao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    estado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_REGIOES", x => x.id_regiao);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIOS",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_regiao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    idade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    doenca_cronica = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIOS", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_TBL_USUARIOS_TBL_REGIOES_id_regiao",
                        column: x => x.id_regiao,
                        principalTable: "TBL_REGIOES",
                        principalColumn: "id_regiao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USUARIOS_id_regiao",
                table: "TBL_USUARIOS",
                column: "id_regiao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_USUARIOS");

            migrationBuilder.DropTable(
                name: "TBL_REGIOES");
        }
    }
}
