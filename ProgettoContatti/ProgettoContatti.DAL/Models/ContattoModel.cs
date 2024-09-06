using ProgettoContatti.ENTITY.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoContatti.DAL.Models
{
    [Table("Contatto")]
    public class ContattoModel
    {
        [Key]
        [Column("Pk_Id")]
        public int IdContatto { get; set; }

        [Column("Fk_Persona_Id")]
        public int IdPersona { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Descrizione { get; set; }

        [Required]
        public ETipoContatto Tipo { get; set; } = ETipoContatto.NumeroDiTelefono;

        [ForeignKey(nameof(IdPersona))]
        [InverseProperty(nameof(PersonaModel.Contatti))]
        public PersonaModel? Persona { get; set; }
    }
}

