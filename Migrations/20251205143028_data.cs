using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progetto_Settimanale.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafiche",
                columns: table => new
                {
                    IdAnagrafica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAP = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Cod_Fisc = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafiche", x => x.IdAnagrafica);
                });

            migrationBuilder.CreateTable(
                name: "TipiViolazione",
                columns: table => new
                {
                    IdViolazione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipiViolazione", x => x.IdViolazione);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    IdVerbale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nominativo_Agente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataTrascrizioneVerbale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false),
                    IdAnagrafica = table.Column<int>(type: "int", nullable: false),
                    IdViolazione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.IdVerbale);
                    table.ForeignKey(
                        name: "FK_Verbali_Anagrafiche_IdAnagrafica",
                        column: x => x.IdAnagrafica,
                        principalTable: "Anagrafiche",
                        principalColumn: "IdAnagrafica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbali_TipiViolazione_IdViolazione",
                        column: x => x.IdViolazione,
                        principalTable: "TipiViolazione",
                        principalColumn: "IdViolazione",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Anagrafiche",
                columns: new[] { "IdAnagrafica", "CAP", "Citta", "Cod_Fisc", "Cognome", "Indirizzo", "Nome" },
                values: new object[,]
                {
                    { 1, "20100", "Milano", "RSSMRA80A01F205X", "Rossi", "Via Roma 10", "Mario" },
                    { 2, "10100", "Torino", "BNCLCU85C10L219Q", "Bianchi", "Corso Italia 55", "Luca" }
                });

            migrationBuilder.InsertData(
                table: "TipiViolazione",
                columns: new[] { "IdViolazione", "Descrizione" },
                values: new object[,]
                {
                    { 1, "Eccesso di velocità oltre 10 km/h" },
                    { 2, "Guida senza cintura" }
                });

            migrationBuilder.InsertData(
                table: "Verbali",
                columns: new[] { "IdVerbale", "DataTrascrizioneVerbale", "DataViolazione", "DecurtamentoPunti", "IdAnagrafica", "IdViolazione", "Importo", "IndirizzoViolazione", "Nominativo_Agente" },
                values: new object[] { 1, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1, 180.50m, "Via Garibaldi 12", "Agente Rossi" });

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_IdAnagrafica",
                table: "Verbali",
                column: "IdAnagrafica");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_IdViolazione",
                table: "Verbali",
                column: "IdViolazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Anagrafiche");

            migrationBuilder.DropTable(
                name: "TipiViolazione");
        }
    }
}
