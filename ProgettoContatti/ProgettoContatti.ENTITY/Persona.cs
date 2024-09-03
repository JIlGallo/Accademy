using ProgettoContatti.ENTITY.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProgettoContatti.BL
{
    public class Persona
    {
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Inserisci il nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Inserisci il cognome")]
        public string Cognome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Inserisci l'età")]
        [Range(1, 120, ErrorMessage = "L'età deve essere compresa tra 1 e 120 anni.")]
        public int Eta { get; set; }

        public DateTime DataDiNascita { get; set; } = new DateTime(2000,01,01);

        public EGenerePersona Genere { get; set; }
        public int IntGenere
        {
            get
            {
                return (int)Genere;
            }

            set
            {
                if (value != 0)
                    Genere = (EGenerePersona)value;
            }
        }

        public List<Contatto>? Contatti { get; set; }
    }

}
