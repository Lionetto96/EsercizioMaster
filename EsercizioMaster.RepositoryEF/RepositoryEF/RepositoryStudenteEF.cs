using EsercizioMaster.Core.IRepository;
using EsercizioMaster.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.RepositoryEF.RepositoryEF
{
    public class RepositoryStudenteEF : IRepositoryStudente
    {
        public Studente Add(Studente item)
        {
            using (var ctx = new Context())
            {
                ctx.Studenti.Add(item);
                ctx.SaveChanges();

            }
            return item;
        }

        public bool Delete(Studente item)
        {
            using (var ctx = new Context())
            {
                ctx.Studenti.Add(item);
                ctx.SaveChanges();

            }
            return true;
        }

        public ICollection<Studente> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Studenti.Include(s=>s.Corso).ToList();
            }
        }

        public Studente GetById(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Studenti.FirstOrDefault(d => d.Id == id);
            }
        }

        public ICollection<Studente> GetStudentiByCorso(string codice)
        {
            using (var ctx = new Context())
            {
                return ctx.Studenti.Where(l => l.Codice == codice).ToList();
            }
        }

        public Studente Update(Studente item)
        {
            using (var ctx = new Context())
            {
                ctx.Studenti.Update(item);
                ctx.SaveChanges();

            }
            return item;
        }
    }
}
