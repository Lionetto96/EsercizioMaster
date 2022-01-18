using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.Models
{
    public class Corso
    {
        public string Codice { get; set; }
        public string Nome { get; set; }

        public string  Descrizione { get; set; }
        //relazione con studente e lezione
        //posso usare ICollection(che è più generico) oppure IList che implementa tutte le tipologie 
        //di liste
        public ICollection<Studente> Studenti { get; set;}=new List<Studente>();
        public ICollection<Lezione> Lezioni { get; set; } =new List<Lezione>();

        public override string ToString()
        {
            return $"{Codice} - {Nome} - {Descrizione}";
        }
    }
}
