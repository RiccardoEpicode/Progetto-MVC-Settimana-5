using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // -------------------------
            // ANAGRAFICA
            // -------------------------
            modelBuilder.Entity<Anagrafica>().HasData(
                new Anagrafica
                {
                    IdAnagrafica = 1,
                    Cognome = "Rossi",
                    Nome = "Mario",
                    Indirizzo = "Via Roma 10",
                    Citta = "Milano",
                    CAP = "20100",
                    Cod_Fisc = "RSSMRA80A01F205X"
                },
                new Anagrafica
                {
                    IdAnagrafica = 2,
                    Cognome = "Bianchi",
                    Nome = "Luca",
                    Indirizzo = "Corso Italia 55",
                    Citta = "Torino",
                    CAP = "10100",
                    Cod_Fisc = "BNCLCU85C10L219Q"
                }
            );

            // -------------------------
            // TIPO VIOLAZIONE
            // -------------------------
            modelBuilder.Entity<TipoViolazione>().HasData(
                new TipoViolazione
                {
                    IdViolazione = 1,
                    Descrizione = "Eccesso di velocità oltre 10 km/h"
                },
                new TipoViolazione
                {
                    IdViolazione = 2,
                    Descrizione = "Guida senza cintura"
                }
            );

            // -------------------------
            // VERBALI
            // -------------------------
            modelBuilder.Entity<Verbale>().HasData(
                new Verbale
                {
                    IdVerbale = 1,
                    DataViolazione = new DateTime(2024, 10, 10),
                    IndirizzoViolazione = "Via Garibaldi 12",
                    Nominativo_Agente = "Agente Rossi",
                    DataTrascrizioneVerbale = new DateTime(2024, 10, 11),
                    Importo = 180.50m,
                    DecurtamentoPunti = 3,
                    IdAnagrafica = 1,
                    IdViolazione = 1
                }
            );
        }
    }
}
