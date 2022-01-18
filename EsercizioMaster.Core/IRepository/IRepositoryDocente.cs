using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.IRepository
{
    public interface IRepositoryDocente : IRepository<Docente>
    {
        public Docente GetById (int id);

    }
}
