using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.Business_Layer
{
    public interface IBusinessLayer
    {
        public List<Corso> GetAllCorsi();
        public Esito AddNuovoCorso(Corso nuovoCorso);
        public Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione);
        public Esito DeleteCorso(string? codice);
        public List<Studente> GetAllStudenti();
        public Esito AddNuovoStudente(Studente nuovoStudente);
        public Esito ModificaEmailStudente(int id,string? nuovaEmail);
        public Esito DeleteStudente(int id);
        public List<Studente> GetAllStudentiDiUnCorso(string codice);
        public Esito DeleteDocente(int id);
        public Esito ModificaDocente(int id, string? nuovaEmail, string? nuovoTelefono);
        public Esito AddNuovoDocente(Docente nuovoDocente);
        public List<Docente> GetAllDocenti();
        public List<Lezione> GetAllLezioni();
        public Esito AddNuovaLezione(Lezione nuovaLezione);
        public Esito ModificaAulaLezione(int id, string? nuovaAula);
        public Esito DeleteLezione(int id);
        public List<Lezione> GetAllLezioniByCodiceCorso(string? codice);
        public List<Lezione> GetAllLezioniByNomeCorso(string? nome);
    }
}
