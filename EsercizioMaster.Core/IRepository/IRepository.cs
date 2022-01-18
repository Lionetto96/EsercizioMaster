using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.IRepository
{
    public interface IRepository<T>
    {
        //OPERAZIONI IN COMUNE A TUTTE LE ENTITA' (CRUD)
        public ICollection<T> GetAll();
        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);
    }
}
