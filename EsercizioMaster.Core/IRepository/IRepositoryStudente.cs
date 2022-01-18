using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.IRepository
{
    public interface IRepositoryStudente :IRepository<Studente>
    {
        public Studente GetById (int id);

        public ICollection<Studente> GetStudentiByCorso(string codice);
    }
}
