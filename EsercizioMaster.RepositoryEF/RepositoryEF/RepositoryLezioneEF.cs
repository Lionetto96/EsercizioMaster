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
    public class RepositoryLezioneEF : IRepositoryLezione
    {
        public Lezione Add(Lezione item)
        {
            using (var ctx = new Context())
            {
                ctx.Lezioni.Add(item);
                ctx.SaveChanges();

            }
            return item;
        }

        public bool Delete(Lezione item)
        {
            using (var ctx = new Context())
            {
                ctx.Lezioni.Remove(item);
                ctx.SaveChanges();

            }
            return true;
        }

        public ICollection<Lezione> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Lezioni.Include(l=>l.Docente).Include(l=>l.Corso).ToList();
            }
        }

        public Lezione GetById(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Lezioni.FirstOrDefault(l=>l.LezioneId==id);
            }
        }

        public ICollection<Lezione> GetLezioniByCoodiceCorso(string codice)
        {
            using (var ctx = new Context())
            {
                return ctx.Lezioni.Where(l=>l.Codice==codice).ToList();
            }
        }

        public ICollection<Lezione> GetLezioniByNomeCorso(string codice)
        {
            using (var ctx = new Context())
            {
                return ctx.Lezioni.Where(l => l.Codice == codice).ToList();
            }
        }

        public Lezione Update(Lezione item)
        {
            using (var ctx = new Context())
            {
                ctx.Lezioni.Update(item);
                ctx.SaveChanges();

            }
            return item;
        }
    }
}
