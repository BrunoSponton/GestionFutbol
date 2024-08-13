using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionFutbol.BD.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsistEntrenamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asistio = table.Column<bool>(type: "bit", nullable: false),
                    JugadorId = table.Column<int>(type: "int", nullable: false),
                    EntrenamientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistEntrenamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrenamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsistEntrenamientoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrenamientos_AsistEntrenamientos_AsistEntrenamientoId",
                        column: x => x.AsistEntrenamientoId,
                        principalTable: "AsistEntrenamientos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstPartidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goles = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Asistencias = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    MinutosJugados = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    JugadorId = table.Column<int>(type: "int", nullable: false),
                    PartidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstPartidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Posicion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AsistEntrenamientoId = table.Column<int>(type: "int", nullable: true),
                    EstPartidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugadores_AsistEntrenamientos_AsistEntrenamientoId",
                        column: x => x.AsistEntrenamientoId,
                        principalTable: "AsistEntrenamientos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jugadores_EstPartidos_EstPartidoId",
                        column: x => x.EstPartidoId,
                        principalTable: "EstPartidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", maxLength: 2, nullable: false),
                    Rival = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EstPartidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidos_EstPartidos_EstPartidoId",
                        column: x => x.EstPartidoId,
                        principalTable: "EstPartidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsistEntrenamientos_EntrenamientoId",
                table: "AsistEntrenamientos",
                column: "EntrenamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsistEntrenamientos_JugadorId",
                table: "AsistEntrenamientos",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenamientos_AsistEntrenamientoId",
                table: "Entrenamientos",
                column: "AsistEntrenamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstPartidos_JugadorId",
                table: "EstPartidos",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EstPartidos_PartidoId",
                table: "EstPartidos",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_AsistEntrenamientoId",
                table: "Jugadores",
                column: "AsistEntrenamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EstPartidoId",
                table: "Jugadores",
                column: "EstPartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EstPartidoId",
                table: "Partidos",
                column: "EstPartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsistEntrenamientos_Entrenamientos_EntrenamientoId",
                table: "AsistEntrenamientos",
                column: "EntrenamientoId",
                principalTable: "Entrenamientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistEntrenamientos_Jugadores_JugadorId",
                table: "AsistEntrenamientos",
                column: "JugadorId",
                principalTable: "Jugadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstPartidos_Jugadores_JugadorId",
                table: "EstPartidos",
                column: "JugadorId",
                principalTable: "Jugadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstPartidos_Partidos_PartidoId",
                table: "EstPartidos",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsistEntrenamientos_Entrenamientos_EntrenamientoId",
                table: "AsistEntrenamientos");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistEntrenamientos_Jugadores_JugadorId",
                table: "AsistEntrenamientos");

            migrationBuilder.DropForeignKey(
                name: "FK_EstPartidos_Jugadores_JugadorId",
                table: "EstPartidos");

            migrationBuilder.DropForeignKey(
                name: "FK_EstPartidos_Partidos_PartidoId",
                table: "EstPartidos");

            migrationBuilder.DropTable(
                name: "Entrenamientos");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "AsistEntrenamientos");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "EstPartidos");
        }
    }
}
