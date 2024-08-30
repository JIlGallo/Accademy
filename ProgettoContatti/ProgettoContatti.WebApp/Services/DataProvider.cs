using ProgettoContatti.BL;
using ProgettoContatti.DAL;
using ProgettoContatti.DAL.Filtri;

namespace ProgettoContatti.WebApp.Services
{
    public class DataProvider
    {
        public List<Persona> GetPersone(PersonaFM filtri)
        {
            PersonaDAL persona = new PersonaDAL();
            return persona.GetPersona(filtri);
        }
        public List<Contatto> GetContatti(int IdPersona)
        {
            ContattoDAL Contatto = new ContattoDAL();
           return Contatto.GetContatto(IdPersona);
               
        }
    }
}
