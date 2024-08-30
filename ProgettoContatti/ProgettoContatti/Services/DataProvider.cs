using ProgettoContatti.BL;
using ProgettoContatti.DAL.DataAccess;
using ProgettoContatti.DAL.Filtri;

namespace ProgettoContatti.Services
{
    public class DataProvider
    {
        public List<Persona> GetPersone(PersonaFM? filtri= null)
        {
            PersonaDAL persona = new PersonaDAL();
            return persona.GetPersona(filtri);
        }
        public Persona? GetPersonaById(int id)
        {
            PersonaDAL persona = new PersonaDAL();
            return persona.GetPersonaById(id);
        }

        public List<Contatto> GetContatti(int IdPersona)
        {
            ContattoDAL Contatto = new ContattoDAL();
           return Contatto.GetContatto(IdPersona);
               
        }
        public Persona GetPersonaByIdContatti(int idPersona)
        {
            PersonaDAL persona = new PersonaDAL();

            return persona.GetPersona(new PersonaFM { Id = idPersona }).FirstOrDefault();
        }
        public int AddPersona(Persona Persona)
        {
            PersonaDAL PersonaDal = new PersonaDAL();
             return PersonaDal.AddPersona(Persona);

        }
        public int ModificaPersona(Persona Persona)
        {
            PersonaDAL PersonaDal = new PersonaDAL();
            return PersonaDal.ModificaPersona(Persona);
        }
        public int EliminaPersona(Persona Persona) 
        {
            PersonaDAL PersonaDal = new PersonaDAL();
            return PersonaDal.EliminaPersona(Persona);
        }
        public int EliminaContatto(Contatto contatto)
        {
            ContattoDAL ContattoDAL = new ContattoDAL();
            return ContattoDAL.EliminaContatto(contatto);
        }
        public int ModificaContatto(Contatto contatto)
        {
            ContattoDAL ContattoDAL = new ContattoDAL();
            return ContattoDAL.ModificaContatto(contatto);
        }




    }
}
