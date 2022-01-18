using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.IRepository
{
    public interface IRepositoryLezione :IRepository<Lezione>
    {
        public Lezione GetById(int id);

        public ICollection<Lezione> GetLezioniByCoodiceCorso(string codice);
        public ICollection<Lezione> GetLezioniByNomeCorso (string codice);
    }
}
