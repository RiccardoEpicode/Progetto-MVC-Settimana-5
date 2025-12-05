using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliziaMunicipale.Models
{
    public class Verbale
    {
        [Key]
        public int IdVerbale { get; set; }

        public DateTime DataViolazione { get; set; }

        [MaxLength(100)]
        public string IndirizzoViolazione { get; set; } = null!;

        [MaxLength(100)]
        public string Nominativo_Agente { get; set; } = null!;

        public DateTime DataTrascrizioneVerbale { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }

        // FK — PERSONA
        public int IdAnagrafica { get; set; }

        [ForeignKey(nameof(IdAnagrafica))]
        public Anagrafica? Anagrafica { get; set; }

        // FK — TIPO VIOLAZIONE
        public int IdViolazione { get; set; }

        [ForeignKey(nameof(IdViolazione))]
        public TipoViolazione? TipoViolazione { get; set; }
    }
}
