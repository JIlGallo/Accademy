using System.ComponentModel.DataAnnotations;

namespace ProgettoContatti.ENTITY.Enums
{
    public enum EGenerePersona
    {
        
        [Display(Name = "Maschio")]
        Maschio = 1,
        [Display(Name = "Femmina")]
        Femmina = 2,
        [Display(Name = "Non Definito")]
        NonDefinito = 3,
    }
}
