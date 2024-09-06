using Microsoft.EntityFrameworkCore;
using ProgettoContatti.DAL.Models;
using ProgettoContatti.ENTITY.Enums;

namespace ProgettoContatti.DAL
{
    public class RubricaContext : DbContext
    {
        public DbSet<ContattoModel> Contatti { get; set; }
        public DbSet<PersonaModel> Persone { get; set; }

        public RubricaContext()
        {
        }
        public RubricaContext(DbContextOptions<RubricaContext> options): base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=10.0.5.55\\DB00;Database=RUBRICA; User Id=sa;Password=Sqlsrv@12345; MultipleActiveResultSets=true;Encrypt=False;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public async Task EnsureSeedData()
        {
            int idPersonaEmanuele = 0;

            #region Persone
            if (Persone != null)
            {
                // controllo se esiste la persona Emanuele Daudo
                if (!Persone.Any(x => x.Nome.ToUpper() == "EMANUELE" && x.Cognome == "DAUDO"))
                {
                    PersonaModel PersonaEmanuele = new PersonaModel();
                    PersonaEmanuele.Nome = "EMANUELE";
                    PersonaEmanuele.Cognome = "DAUDO";
                    PersonaEmanuele.Eta = 24;
                    PersonaEmanuele.DataDiNascita = new DateTime(2000, 7, 13);
                    PersonaEmanuele.Genere = EGenerePersona.Maschio;
                    Persone.Add(PersonaEmanuele);
                    await SaveChangesAsync();
                    idPersonaEmanuele = PersonaEmanuele.IdPersona;
                }
                else
                    idPersonaEmanuele = Persone.First(x => x.Nome.ToUpper() == "EMANUELE" && x.Cognome == "DAUDO").IdPersona;
            }
            #endregion

            #region Contatti
            // controllo se esistono i contatti di Emanuele Daudo 

            if (Contatti != null)
            {
                // controllo se esiste un numero di telefono
                if (!Contatti.Any(x => x.IdPersona == idPersonaEmanuele && x.Tipo == ETipoContatto.NumeroDiTelefono))
                {
                    ContattoModel cellulareEmanuele = new ContattoModel()
                    {
                        Tipo = ETipoContatto.NumeroDiTelefono,
                        Descrizione = "+39 348 684 6890",
                        IdPersona = idPersonaEmanuele,
                    };
                    Contatti.Add(cellulareEmanuele);
                    await SaveChangesAsync();
                }

                // controllo se esiste un indirizzo
                if (!Contatti.Any(x => x.IdPersona == idPersonaEmanuele && x.Tipo == ETipoContatto.Indirizzo))
                {
                    ContattoModel cellulareEmanuele = new ContattoModel()
                    {
                        Tipo = ETipoContatto.Indirizzo,
                        Descrizione = "Via Vercelli 13 Gassino (TO)",
                        IdPersona = idPersonaEmanuele,
                    };
                    Contatti.Add(cellulareEmanuele);
                    await SaveChangesAsync();
                }
            }
            #endregion
        }
        
        public List<PersonaModel> GetPersoneConContatti()
        {
            return Persone.Include(c => c.Contatti).ToList();
        }
        public PersonaModel GetPersonaConContatti(int id)
        {
            return Persone.Include(c => c.Contatti).Single(x => x.IdPersona == id);
        }


    }
}

