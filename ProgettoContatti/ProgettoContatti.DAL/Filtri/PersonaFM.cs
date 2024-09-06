using ProgettoContatti.ENTITY.Enums;

namespace ProgettoContatti.DAL.Filtri
{
    public class PersonaFM
    {
        public int? Id  { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public int? RangeEtaDa { get; set; }
        public int? RangeEtaA { get; set; }
        public int? RangeAnnoNascitaDa { get; set; }
        public int? RangeAnnoNascitaA { get; set; }
        public EGenerePersona? Genere { get; set; }
    }
}
