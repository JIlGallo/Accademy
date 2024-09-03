using ProgettoContatti.ENTITY.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoContatti.DAL.Models
{
    [Table("Persona")]
    public class PersonaModel
    {
        [Key]
        [Column("Pk_Id")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage ="Inserisci il nome")]
        [MaxLength(30)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Inserisci il cognome")]
        [MaxLength(30)]
        public string Cognome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Inserisci l'età")]
        [Range(1, 120, ErrorMessage = "L'età deve essere compresa tra 1 e 120 anni.")]
        public int Eta { get; set; }

        [Required(ErrorMessage = "Inserisci la data di nascita")]
        public DateTime DataDiNascita { get; set; }

        public EGenerePersona Genere { get; set; }

        [InverseProperty(nameof(ContattoModel.Persona))]
        public List<ContattoModel>? Contatti { get; set; }
    }
}
