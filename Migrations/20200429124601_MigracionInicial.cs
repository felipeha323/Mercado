using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    PaisId = table.Column<int>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unidad_Residencial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidad_Residencial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidad_Residencial_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apartamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Piso = table.Column<int>(nullable: false),
                    Bloque = table.Column<int>(nullable: false),
                    UnidadId = table.Column<int>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartamento_Unidad_Residencial_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidad_Residencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartamentoID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propietario_Apartamento_ApartamentoID",
                        column: x => x.ApartamentoID,
                        principalTable: "Apartamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_creacion = table.Column<DateTime>(nullable: false),
                    PropietarioId = table.Column<int>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mercado_Propietario_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_mercado = table.Column<int>(nullable: false),
                    Id_producto = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Mercado_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Mercado_Mercado_Id",
                        column: x => x.Mercado_Id,
                        principalTable: "Mercado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Unidad_de_Medida = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    CompraId = table.Column<int>(nullable: true),
                    Mercado_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_Mercado_Mercado_Id",
                        column: x => x.Mercado_Id,
                        principalTable: "Mercado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamento_UnidadId",
                table: "Apartamento",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_DepartamentoId",
                table: "Ciudad",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Mercado_Id",
                table: "Compra",
                column: "Mercado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_PaisId",
                table: "Departamento",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercado_PropietarioId",
                table: "Mercado",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CompraId",
                table: "Producto",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Mercado_Id",
                table: "Producto",
                column: "Mercado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Propietario_ApartamentoID",
                table: "Propietario",
                column: "ApartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Unidad_Residencial_CiudadId",
                table: "Unidad_Residencial",
                column: "CiudadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Mercado");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Apartamento");

            migrationBuilder.DropTable(
                name: "Unidad_Residencial");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
