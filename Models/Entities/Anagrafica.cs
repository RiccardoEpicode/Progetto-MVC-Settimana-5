using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class Anagrafica
    {
        [Key]
        public int IdAnagrafica { get; set; }

        [Required, MaxLength(50)]
        public string Cognome { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Nome { get; set; } = null!;

        [MaxLength(100)]
        public string Indirizzo { get; set; } = null!;

        [MaxLength(50)]
        public string Citta { get; set; } = null!;

        [MaxLength(5)]
        public string CAP { get; set; } = null!;

        [MaxLength(16)]
        public string Cod_Fisc { get; set; } = null!;

        public ICollection<Verbale>? Verbali { get; set; }
    }
}
