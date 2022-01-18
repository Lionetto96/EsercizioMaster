using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.IRepository
{
    public interface IRepositoryCorso :IRepository<Corso>
    {
        public Corso GetByCode(string codice);
        public string GetIDByNomeCorso(string nome);
    }
}
