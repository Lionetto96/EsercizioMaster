using EsercizioMaster.Core.IRepository;
using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.RepositoryMock.Repository
{
    public class RepositoryCorso : IRepositoryCorso
    {
        public static List<Corso> corsi = new List<Corso>()
        {
            new Corso{Codice="C-01", Nome="Pre-Academy A", Descrizione="descr1 "},
            new Corso{ Codice = "C-02", Nome = "Academy A", Descrizione = "descr2 "},
            new Corso{ Codice = "C-03", Nome = "Academy A", Descrizione = "descr3 "}

        };
        public Corso Add(Corso item)
        {
            corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
            corsi.Remove(item);
            return true;
        }

        public ICollection<Corso> GetAll()
        {
            return corsi;
        }

        public Corso GetByCode(string codice)
        {
            var corso= corsi.FirstOrDefault(c => c.Codice == codice);
            if(corso!= null)
            {
                return corso;
            }
            else
            {
                return null;
            }
        }

        public string GetIDByNomeCorso(string? nome)
        {
            var corso=corsi.FirstOrDefault(c=>c.Nome == nome);
            if (corso != null)
            {
                return corso.Codice;
            }
            else
            {
                return null;
            }
        }

        public Corso Update(Corso item)
        {
            foreach(var c in corsi)
            {
                if(c.Codice == item.Codice)
                {
                    c.Nome = item.Nome;
                    c.Descrizione = item.Descrizione;
                    return c;
                }
            }
            return null;
        }
    }
}
