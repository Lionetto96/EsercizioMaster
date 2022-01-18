using EsercizioMaster.Core.IRepository;
using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.RepositoryMock.Repository
{
    public class RepositoryStudente : IRepositoryStudente
    {
        public static List<Studente> studenti = new List<Studente>()
        {
            new Studente{Id=1, Nome="alessia",  Cognome="lionetto", Email="ale.lio@gmail.com",DataNascita=new DateTime(1996,08,19),TitoloStudio="laurea breve",Codice="C-01"},
            new Studente{Id=2, Nome="mario",  Cognome="rossi", Email="mario23@gmail.com",DataNascita=new DateTime(1994,08,17),TitoloStudio="laurea magistrale",Codice="C-01"}

        };
        public Studente Add(Studente item)
        {
            studenti.Add(item);
            return item;
        }

        public bool Delete(Studente item)
        {
            studenti.Remove(item);
            return true;
        }

        public ICollection<Studente> GetAll()
        {
            return studenti;
        }

        public Studente GetById(int id)
        {
            return studenti.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Studente> GetStudentiByCorso(string codice)
        {
            return studenti.Where(s=>s.Codice == codice).ToList();
        }

        

        public Studente Update(Studente item)
        {
            foreach (var s in studenti)
            {
                if (s.Codice == item.Codice)
                {
                    s.Email = item.Email;
                    return s;
                }
            }
            return null;
        }
    }
}
