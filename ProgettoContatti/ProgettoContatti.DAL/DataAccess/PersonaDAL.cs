using Microsoft.EntityFrameworkCore;
using ProgettoContatti.BL;
using ProgettoContatti.DAL.Filtri;
using ProgettoContatti.DAL.Models;
using ProgettoContatti.ENTITY.Enums;
using System.Collections.Generic;

namespace ProgettoContatti.DAL.DataAccess
{
    public class PersonaDAL
    {
        RubricaContext Context { get; set; } = new RubricaContext();
        public void SetPersona(Persona persona)
        {
            throw new NotImplementedException();
        }
        //public List<Persona> GetPersona(PersonaFM? Filtri = null)
        //{
        //    List<Persona> persone = new List<Persona>()
        //    {

        //    new Persona{IdPersona=1,Nome="Ciccio",Cognome="Panza",Genere=EGenerePersona.Maschio,Eta=34,DataDiNascita= new DateTime(1986,07,23)},
        //    new Persona{IdPersona=2,Nome="Nello",Cognome="Panzona",Genere=EGenerePersona.Femmina,Eta=67,DataDiNascita= new DateTime(1986,02,25)},
        //    new Persona{IdPersona=3,Nome="Maccio",Cognome="Pane",Genere=EGenerePersona.Maschio,Eta=31,DataDiNascita= new DateTime(1989,05,3)},
        //    new Persona{IdPersona=4,Nome="Roberto",Cognome="Canzoni",Genere=EGenerePersona.Maschio,Eta=76,DataDiNascita= new DateTime(1947,03,2),},
        //    new Persona{IdPersona=5,Nome="Carlo",Cognome="Tarollo",Genere=EGenerePersona.Femmina,Eta=13,DataDiNascita= new DateTime(2011,09,29),},
        //    new Persona{IdPersona=6,Nome="Marco",Cognome="Sinola",Genere=EGenerePersona.Maschio,Eta=26,DataDiNascita= new DateTime(1996,09,13),},
        //    new Persona{IdPersona=7,Nome="Danilo",Cognome="Lartona",Genere=EGenerePersona.Femmina,Eta=54,DataDiNascita= new DateTime(1969,01,7),}
        //    };

        //    //Applico i Filtri
        //    if (Filtri != null)
        //    {
        //        if (!string.IsNullOrEmpty(Filtri.Nome))
        //            persone = persone.Where(x => x.Nome.ToUpper().Contains(Filtri.Nome.ToUpper())).ToList();
        //        if (!string.IsNullOrEmpty(Filtri.Cognome))
        //            persone = persone.Where(x => x.Cognome.ToUpper().Contains(Filtri.Cognome.ToUpper())).ToList();
        //        if (Filtri.RangeAnnoNascitaDa.HasValue)
        //            persone = persone.Where(x => x.DataDiNascita.Date.Year >= Filtri.RangeAnnoNascitaDa.Value).ToList();
        //        if (Filtri.RangeAnnoNascitaA.HasValue)
        //            persone = persone.Where(x => x.DataDiNascita.Date.Year <= Filtri.RangeAnnoNascitaA.Value).ToList();
        //        if (Filtri.RangeEtaDa.HasValue)
        //            persone = persone.Where(x => x.Eta >= Filtri.RangeEtaDa.Value).ToList();
        //        if (Filtri.RangeEtaA.HasValue)
        //            persone = persone.Where(x => x.Eta <= Filtri.RangeEtaA.Value).ToList();
        //        if (Filtri.Genere.HasValue)
        //            persone = persone.Where(x => x.Genere == Filtri.Genere).ToList();
        //    }
        //    return persone;
        //}

        public int AddPersona(Persona persona)
        {
            var nuovaPersona = new PersonaModel
            {
                Nome = persona.Nome,
                Cognome = persona.Cognome,
                Eta = persona.Eta,
                DataDiNascita = persona.DataDiNascita,
                Genere = persona.Genere
            };

            if (persona.Contatti != null && persona.Contatti.Count > 0)
            {

                nuovaPersona.Contatti = new List<ContattoModel>();
                foreach (var contatto in persona.Contatti)
                {
                    nuovaPersona.Contatti.Add(new ContattoModel()
                    {
                        Descrizione = contatto.Descrizione,
                        Tipo = contatto.Tipo
                    });
                }
            }
            Context.Persone.Add(nuovaPersona);
            Context.SaveChanges();
            return 0;
        }
        public int ModificaPersona(Persona persona)
        {
            var existingPersona = Context.Persone.FirstOrDefault(p => p.IdPersona == persona.IdPersona);

            existingPersona.Nome = persona.Nome;
            existingPersona.Cognome = persona.Cognome;
            existingPersona.Eta = persona.Eta;
            existingPersona.DataDiNascita = persona.DataDiNascita;
            existingPersona.Genere = persona.Genere;

            Context.SaveChanges();
            return existingPersona.IdPersona;
        
        }
        public int EliminaPersona(Persona persona)
        {
            var personaEliminata = Context.Persone.FirstOrDefault(p => p.IdPersona == persona.IdPersona);
            if (personaEliminata != null)
            {
                //Context.Contatti.RemoveRange(personaEliminata.Contatti);
                Context.Persone.Remove(personaEliminata);

                Context.SaveChanges();

                return personaEliminata.IdPersona;
            }
            return 0;
        }
        public List<Persona> GetPersona(PersonaFM? Filtri = null)
        {
            List<Persona> personeBl = new List<Persona>();
            List<PersonaModel> persone = Context.Persone
                   .Include(p => p.Contatti) 
                   .ToList();
            #region Filtri
            if (Filtri != null)
            {
                if (Filtri.Id.HasValue)
                {
                    persone = persone.Where(x => x.IdPersona == Filtri.Id).ToList();
                }

                if (!string.IsNullOrEmpty(Filtri.Nome))
                {
                    persone = persone.Where(x => x.Nome.ToUpper().Contains(Filtri.Nome.ToUpper())).ToList();
                }
                if (!string.IsNullOrEmpty(Filtri.Cognome))
                {
                    persone = persone.Where(x => x.Cognome.ToUpper().Contains(Filtri.Cognome.ToUpper())).ToList();
                }
                if (Filtri.RangeAnnoNascitaDa.HasValue)
                {
                    persone = persone.Where(x => x.DataDiNascita.Year >= Filtri.RangeAnnoNascitaDa.Value).ToList();
                }
                if (Filtri.RangeAnnoNascitaA.HasValue)
                {
                    persone = persone.Where(x => x.DataDiNascita.Year <= Filtri.RangeAnnoNascitaA.Value).ToList();
                }
                if (Filtri.RangeEtaDa.HasValue)
                {
                    persone = persone.Where(x => x.Eta >= Filtri.RangeEtaDa.Value).ToList();
                }
                if (Filtri.RangeEtaA.HasValue)
                {
                    persone = persone.Where(x => x.Eta <= Filtri.RangeEtaA.Value).ToList();
                }
                if (Filtri.Genere.HasValue)
                {
                    persone = persone.Where(x => x.Genere == Filtri.Genere.Value).ToList();
                }
            }
            #endregion

            #region convert entity object into business object
            foreach (var model in persone)
            {
                Persona pBl = new Persona
                {
                    IdPersona = model.IdPersona,
                    Nome = model.Nome,
                    Cognome = model.Cognome,
                    Eta = model.Eta,
                    DataDiNascita = model.DataDiNascita,
                    Genere = model.Genere,
                    Contatti = model.Contatti?.Select(c => new Contatto
                    {
                        IdContatto = c.IdContatto,
                        Descrizione = c.Descrizione,
                       Tipo = c.Tipo
                    }).ToList()
                };
                personeBl.Add(pBl);
            }
            return personeBl;
            #endregion
        }
        public Persona? GetPersonaById(int id)
        {
            Persona? persona = null;

            PersonaFM filtri = new PersonaFM() { Id = id};
            var result =  GetPersona(filtri);
            if (result == null || result.Count == 0)
                return null;
            persona = result.FirstOrDefault(); 
            return persona;
        }

    }
}
