using ProgettoContatti.ENTITY.Enums;

namespace ProgettoContatti.BL
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
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
