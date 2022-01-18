using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.Models
{
    public class Studente :Persona
    {
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }
        //fk verso corso
        public string Codice { get; set; }
        public Corso Corso { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" nato il: {DataNascita.ToShortDateString()} -titolo di studio: {TitoloStudio} corso: {Corso}";
        }
    }
}
