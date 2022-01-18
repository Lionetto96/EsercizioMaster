using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.Models
{
    public class Docente :Persona
    {
        public string NumeroTelefono { get; set; }
        //relazione con Lezione
        public ICollection<Lezione> Lezioni { get; set; }=new List<Lezione>();

        public override string ToString()
        {
            return base.ToString() + $" telefono: {NumeroTelefono} ";
        }
    }
}
