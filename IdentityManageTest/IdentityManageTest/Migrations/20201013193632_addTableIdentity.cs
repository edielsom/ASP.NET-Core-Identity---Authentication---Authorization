using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityManager.Migrations
{
    public partial class addTableIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetPapel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NomePapel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SeloSimultaniedade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetPapel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BancoDados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeUsuario = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NomeUsuarioNormal = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailNormal = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeloSeguranca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeloSimultanidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    TelefoneConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    BloqueioLigado = table.Column<bool>(type: "bit", nullable: false),
                    FimBloqueio = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    QuantidadeAcessoFalhado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetPapelPermissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoPermissao = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ValorPermissao = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetPapelPermissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetPapelPermissao_AspNetPapel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetPapel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsuarioLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderSenha = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeProvedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsuarioLogin", x => new { x.LoginProvider, x.ProviderSenha });
                    table.ForeignKey(
                        name: "FK_AspNetUsuarioLogin_AspNetUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsuarioPapel",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PapelId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsuarioPapel", x => new { x.UsuarioId, x.PapelId });
                    table.ForeignKey(
                        name: "FK_AspNetUsuarioPapel_AspNetPapel_PapelId",
                        column: x => x.PapelId,
                        principalTable: "AspNetPapel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsuarioPapel_AspNetUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsuarioPermissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoPermissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorPermissao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsuarioPermissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsuarioPermissao_AspNetUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsuarioToken",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsuarioToken", x => new { x.UsuarioId, x.LoginProvider, x.Nome });
                    table.ForeignKey(
                        name: "FK_AspNetUsuarioToken_AspNetUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetPapel",
                column: "NomePapel",
                unique: true,
                filter: "[NomePapel] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetPapelPermissao_RoleId",
                table: "AspNetPapelPermissao",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsuario",
                column: "EmailNormal");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsuario",
                column: "NomeUsuarioNormal",
                unique: true,
                filter: "[NomeUsuarioNormal] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsuarioLogin_UsuarioId",
                table: "AspNetUsuarioLogin",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsuarioPapel_PapelId",
                table: "AspNetUsuarioPapel",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsuarioPermissao_UsuarioId",
                table: "AspNetUsuarioPermissao",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetPapelPermissao");

            migrationBuilder.DropTable(
                name: "AspNetUsuarioLogin");

            migrationBuilder.DropTable(
                name: "AspNetUsuarioPapel");

            migrationBuilder.DropTable(
                name: "AspNetUsuarioPermissao");

            migrationBuilder.DropTable(
                name: "AspNetUsuarioToken");

            migrationBuilder.DropTable(
                name: "AspNetPapel");

            migrationBuilder.DropTable(
                name: "AspNetUsuario");
        }
    }
}
