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
    public class RepositoryCorsoEF : IRepositoryCorso
    {
        //private readonly Context ctx;
        //public RepositoryCorsoEF(Context context)
        //{
        //    ctx = context;
        //}
        public RepositoryCorsoEF()
        {

        }
        public Corso Add(Corso item)
        {
            using(var ctx=new Context())
            {
                ctx.Corsi.Add(item);
                ctx.SaveChanges();
                
            }
            return item;

        }

        public bool Delete(Corso item)
        {
            using (var ctx = new Context())
            {
                ctx.Corsi.Remove(item);
                ctx.SaveChanges();

            }
            return true;
        }

        public ICollection<Corso> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Corsi.Include(c => c.Studenti).ToList();
            }
                
        }

        public Corso GetByCode(string codice)
        {
            using (var ctx = new Context())
            {
                return ctx.Corsi.FirstOrDefault(c => c.Codice == codice);
            }
                
        }

        public string GetIDByNomeCorso(string nome)
        {
            using (var ctx = new Context())
            {
                var corso = ctx.Corsi.FirstOrDefault(c => c.Nome == nome);
                if (corso != null)
                {
                    return corso.Codice;
                }
                else
                {
                    return null;
                }
                
            }
        }

        public Corso Update(Corso item)
        {

            using (var ctx = new Context())
            {
                ctx.Corsi.Update(item);
                ctx.SaveChanges();

            }
            return item;
        }
    }
}
