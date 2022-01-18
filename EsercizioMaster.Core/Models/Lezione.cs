using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.Models
{
    public class Lezione
    {
        public int LezioneId { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }
        //FK verso docente 
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }
        //FK verso Corso
        public string Codice { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $" lezione: {LezioneId} - data: {DataOraInizio} - durata in gg: {Durata} - aula: {Aula} docente:{Docente} corso:{Corso}";
        }
    }
}
