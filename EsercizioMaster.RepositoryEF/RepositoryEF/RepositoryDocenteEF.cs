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
    public class RepositoryDocenteEF : IRepositoryDocente
    {
        public Docente Add(Docente item)
        {
            using (var ctx = new Context())
            {
                ctx.Docenti.Add(item);
                ctx.SaveChanges();

            }
            return item;
        }

        public bool Delete(Docente item)
        {
            using (var ctx = new Context())
            {
                ctx.Docenti.Remove(item);
                ctx.SaveChanges();

            }
            return true;
        }

        public ICollection<Docente> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Docenti.Include(l=>l.Lezioni).ToList();
            }
        }

        public Docente GetById(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Docenti.FirstOrDefault(d => d.Id == id);
            }
        }

        public Docente Update(Docente item)
        {
            using (var ctx = new Context())
            {
                ctx.Docenti.Update(item);
                ctx.SaveChanges();

            }
            return item;
        }
    }
}
