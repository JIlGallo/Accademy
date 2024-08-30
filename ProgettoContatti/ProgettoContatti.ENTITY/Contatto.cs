using ProgettoContatti.ENTITY.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoContatti.BL
{
    public class Contatto
    {
        public int IdContatto { get; set; }
        public int IdPersona { get; set; }
        public string? Descrizione { get; set; }
        public ETipoContatto Tipo { get; set; } = ETipoContatto.NumeroDiTelefono;
        public int IntTipo
        {
            get
            { 
                return (int)Tipo;
            }

            set
            {
                if(value != 0)
                    Tipo = (ETipoContatto)value;
            }
        }
        public Persona Persona { get; set; }

    }
}
