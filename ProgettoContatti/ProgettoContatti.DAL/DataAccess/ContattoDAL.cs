using ProgettoContatti.BL;
using ProgettoContatti.DAL.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProgettoContatti.DAL.DataAccess
{

    public class ContattoDAL
    {
        RubricaContext Context { get; set; } = new RubricaContext();

        public void SetContatto(Contatto contatto)
        {
            throw new NotImplementedException();
        }
        public List<Contatto> GetContatto(int IdPersona)
        {
            List<Contatto> contatti = new List<Contatto>()
            {
                new Contatto {IdContatto=1,IdPersona=1,Descrizione="355 674 5687",Tipo=ENTITY.Enums.ETipoContatto.NumeroDiTelefono},
                new Contatto {IdContatto=2,IdPersona=1,Descrizione="Via ciaoliao 87",Tipo=ENTITY.Enums.ETipoContatto.Indirizzo},
                new Contatto {IdContatto=3,IdPersona=1,Descrizione="gnanolia@gmail.it",Tipo=ENTITY.Enums.ETipoContatto.Email},
                new Contatto {IdContatto=4,IdPersona=1,Descrizione="www.lalal.it",Tipo=ENTITY.Enums.ETipoContatto.SitoWeb},

                new Contatto {IdContatto=5,IdPersona=2,Descrizione="miamomao@gmail.it",Tipo=ENTITY.Enums.ETipoContatto.Email},
                new Contatto {IdContatto=6,IdPersona=2,Descrizione="366 786 5643",Tipo=ENTITY.Enums.ETipoContatto.NumeroDiTelefono},
                new Contatto {IdContatto=7,IdPersona=2,Descrizione="Corso frastuoni 78",Tipo=ENTITY.Enums.ETipoContatto.Indirizzo},
                new Contatto {IdContatto=8,IdPersona=2,Descrizione="www.lontano.it",Tipo=ENTITY.Enums.ETipoContatto.SitoWeb},

                new Contatto {IdContatto=9,IdPersona=3,Descrizione="Via Cafasso 67",Tipo=ENTITY.Enums.ETipoContatto.Indirizzo},
                new Contatto {IdContatto=10,IdPersona=3,Descrizione="366 786 5643",Tipo=ENTITY.Enums.ETipoContatto.NumeroDiTelefono},
                new Contatto {IdContatto=11,IdPersona=3,Descrizione="Corso frastuoni 78",Tipo=ENTITY.Enums.ETipoContatto.Indirizzo},
                new Contatto {IdContatto=12,IdPersona=3,Descrizione="www.lontano.it",Tipo=ENTITY.Enums.ETipoContatto.SitoWeb},

                new Contatto {IdContatto=13,IdPersona=4,Descrizione="Cacchiarola@gmail.it",Tipo=ENTITY.Enums.ETipoContatto.Email},
                new Contatto {IdContatto=14,IdPersona=4,Descrizione="366 786 5643",Tipo=ENTITY.Enums.ETipoContatto.NumeroDiTelefono},
                new Contatto {IdContatto=15,IdPersona=4,Descrizione="Corso frastuoni 78",Tipo=ENTITY.Enums.ETipoContatto.Indirizzo},
                new Contatto {IdContatto=16,IdPersona=4,Descrizione="www.lontano.it",Tipo=ENTITY.Enums.ETipoContatto.SitoWeb},

                new Contatto {IdContatto=17,IdPersona=5,Descrizione="366 688 5687",Tipo=ENTITY.Enums.ETipoContatto.NumeroDiTelefono},

                new Contatto {IdContatto=18,IdPersona=6,Descrizione="www.seipazzo.org",Tipo=ENTITY.Enums.ETipoContatto.SitoWeb},

                new Contatto {IdContatto=19,IdPersona=7,Descrizione="www.miaomiao.it",Tipo=ENTITY.Enums.ETipoContatto.SitoWeb}

            };
            if (IdPersona != 0)
                contatti = contatti.Where(x => x.IdPersona == IdPersona).ToList();

            return contatti;
        }

        public int EliminaContatto(Contatto contatto)
        {
            var contattoDaEliminare = Context.Contatti.Find(contatto.IdContatto);
            if (contattoDaEliminare != null)
            {

                Context.Contatti.Remove(contattoDaEliminare);
                Context.SaveChanges();
                return contatto.IdContatto;
            }
            return 0;
        }
        public int ModificaContatto(Contatto contatto)
        {
            var contattoModificato = Context.Contatti.Find(contatto.IdContatto);
            if (contattoModificato != null)
            {
                contattoModificato.Descrizione = contatto.Descrizione;
                contattoModificato.Tipo = contatto.Tipo;
                Context.Contatti.Update(contattoModificato);
                Context.SaveChanges();
                return contatto.IdContatto;
            }
            return 0;

        }
        public int AggiungiContatto(Contatto contatto)
        {
            ContattoModel contattom= new ContattoModel();
            contattom.IdPersona = contatto.IdPersona;
            contattom.Descrizione = contatto.Descrizione;
            contattom.Tipo = contatto.Tipo;
            if (contatto != null)
            {
                Context.Contatti.Add(contattom);
                Context.SaveChanges();
                return contattom.IdContatto;

            }
            return 0;
        }
    }
}

