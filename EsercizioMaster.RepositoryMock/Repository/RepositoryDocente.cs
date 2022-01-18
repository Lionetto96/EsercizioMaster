using EsercizioMaster.Core.IRepository;
using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.RepositoryMock.Repository
{
    public class RepositoryDocente :IRepositoryDocente
    {
        public static List<Docente> docenti = new List<Docente>()
        {
            new Docente{Id=1, Nome="chiara",  Cognome="lionetto", Email="chiara.lio@gmail.com",NumeroTelefono="345271527337"},
            new Docente{Id=2, Nome="piero",  Cognome="rossi", Email="piero21@gmail.com",NumeroTelefono="33384748483"}

        };
        public Docente GetById(int id)
        {
            return docenti.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Docente> GetAll()
        {
            return docenti;
        }

        public Docente Add(Docente item)
        {
            docenti.Add(item);
            return item;
        }

        public Docente Update(Docente item)
        {
            foreach (var d in docenti)
            {
                if (d.Id==item.Id)
                {
                    d.Email = item.Email;
                    d.NumeroTelefono = item.NumeroTelefono;
                    return d;
                }
            }
            return null;
        }

        public bool Delete(Docente item)
        {
            docenti.Remove(item);
            return true;
        }

        
    }
}
