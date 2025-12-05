using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class TipoViolazione
    {
        [Key]
        public int IdViolazione { get; set; }

        [Required, MaxLength(200)]
        public string Descrizione { get; set; } = null!;

        public ICollection<Verbale>? Verbali { get; set; }
    }
}
