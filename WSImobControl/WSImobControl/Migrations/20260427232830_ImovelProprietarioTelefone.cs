using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSImobControl.Migrations
{
    /// <inheritdoc />
    public partial class ImovelProprietarioTelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Imovel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Imovel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "ProprietarioId",
                table: "Imovel",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ProprietarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_ProprietarioId",
                table: "Imovel",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_ProprietarioId",
                table: "Telefone",
                column: "ProprietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Proprietario_ProprietarioId",
                table: "Imovel",
                column: "ProprietarioId",
                principalTable: "Proprietario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Proprietario_ProprietarioId",
                table: "Imovel");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Imovel_ProprietarioId",
                table: "Imovel");

            migrationBuilder.DropColumn(
                name: "ProprietarioId",
                table: "Imovel");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Imovel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Imovel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
