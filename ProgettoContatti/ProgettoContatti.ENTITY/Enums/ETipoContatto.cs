using System.ComponentModel.DataAnnotations;

namespace ProgettoContatti.ENTITY.Enums
{
    public enum ETipoContatto
    {
        [Display(Name = "Numero di telefono")]
        NumeroDiTelefono = 1,
        [Display(Name = "Email")]
        Email = 2,
        [Display(Name = "Indirizzo")]
        Indirizzo = 3,
        [Display(Name = "Sito Web")]
        SitoWeb = 4,
    }
}
