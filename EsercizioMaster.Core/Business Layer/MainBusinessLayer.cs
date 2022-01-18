using EsercizioMaster.Core.IRepository;
using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.Core.Business_Layer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorso corsiRepo;
        private readonly IRepositoryStudente studentiRepo;
        private readonly IRepositoryDocente docentiRepo;
        private readonly IRepositoryLezione lezioniRepo;
        
        //costruttore
        public MainBusinessLayer(IRepositoryCorso corsi,IRepositoryStudente studenti,IRepositoryDocente docenti,IRepositoryLezione lezioni)
        {
            corsiRepo = corsi;
            studentiRepo = studenti;
            docentiRepo=docenti;
            lezioniRepo=lezioni;
        }

        public Esito AddNuovaLezione(Lezione nuovaLezione)
        {
            //controllo se il codice inserito esiste 
            Lezione lezioneEsistente = lezioniRepo.GetById(nuovaLezione.LezioneId);
            
            if (lezioneEsistente == null)
            {
                //aggiungo la nuova lezione
                lezioniRepo.Add(nuovaLezione);
                return new Esito { Messaggio = "lezione aggiunta", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio = "impossibile aggiungere la lezione", IsOk = false };
            }
        }

        public Esito AddNuovoCorso(Corso nuovoCorso)
        {
            //controllo se il codice inserito esiste 
            Corso corsoEsistente =corsiRepo.GetByCode(nuovoCorso.Codice);
            //oppure:
            //corsiRepo.GetAll().FirstOrDefault(c => c.Codice == nuovoCorso.Codice);
            if (corsoEsistente == null)
            {
                //aggiungo il nuovo corso
                corsiRepo.Add(nuovoCorso);
                return new Esito { Messaggio = "corso aggiunto", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio="impossibile aggiungere il corso",IsOk = false };
            }
            
            
        }

        public Esito AddNuovoDocente(Docente nuovoDocente)
        {
            //controllo se id inserito esiste 
            Docente docenteEsistente = docentiRepo.GetById(nuovoDocente.Id);

            if (docenteEsistente == null)
            {
                //aggiungo il nuovo studente
                docentiRepo.Add(nuovoDocente);
                return new Esito { Messaggio = "docente aggiunto", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio = "impossibile aggiungere il docente", IsOk = false };
            }
        }

        public Esito AddNuovoStudente(Studente nuovoStudente)
        {
            //controllo se id inserito esiste 
            Studente studenteEsistente = studentiRepo.GetById(nuovoStudente.Id);
            
            if (studenteEsistente == null)
            {
                //aggiungo il nuovo studente
                studentiRepo.Add(nuovoStudente);
                return new Esito { Messaggio = "studente aggiunto", IsOk = true };
            }
            else
            {
                return new Esito { Messaggio = "impossibile aggiungere lo studente", IsOk = false };
            }
        }

        public Esito DeleteCorso(string? codice)
        {
            var corsoEsistente = corsiRepo.GetByCode(codice);
            if (corsoEsistente == null)
            {
                return new Esito { Messaggio = "codice non trovato", IsOk = false };


            }
            else
            {
                
                corsiRepo.Delete(corsoEsistente);
                return new Esito { Messaggio = "corso eliminato correttamente", IsOk = true };
            }
        }

        public Esito DeleteDocente(int id)
        {
            var docenteEsistente = docentiRepo.GetById(id);
            if (docenteEsistente == null)
            {
                return new Esito { Messaggio = "id non trovato", IsOk = false };


            }
            else
            {

                docentiRepo.Delete(docenteEsistente);
                return new Esito { Messaggio = "docente eliminato correttamente", IsOk = true };
            }
        }

        public Esito DeleteLezione(int id)
        {
            var lezioneEsistente = lezioniRepo.GetById(id);
            if (lezioneEsistente == null)
            {
                return new Esito { Messaggio = "id non trovato", IsOk = false };


            }
            else
            {

                lezioniRepo.Delete(lezioneEsistente);
                return new Esito { Messaggio = "lezione eliminata correttamente", IsOk = true };
            }
        }

        public Esito DeleteStudente(int id)
        {
            var studenteEsistente = studentiRepo.GetById(id);
            if (studenteEsistente == null)
            {
                return new Esito { Messaggio = "id non trovato", IsOk = false };


            }
            else
            {

                studentiRepo.Delete(studenteEsistente);
                return new Esito { Messaggio = "studente eliminato correttamente", IsOk = true };
            }
        }

        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll().ToList();
        }

        public List<Docente> GetAllDocenti()
        {
            return docentiRepo.GetAll().ToList();
        }

        public List<Lezione> GetAllLezioni()
        {
            return lezioniRepo.GetAll().ToList();
        }

        public List<Lezione> GetAllLezioniByCodiceCorso(string? codice)
        {
            return lezioniRepo.GetLezioniByCoodiceCorso(codice).ToList();
        }

        public List<Lezione> GetAllLezioniByNomeCorso(string? nome)
        {
            var codiceCorsoEsistente= corsiRepo.GetIDByNomeCorso(nome);
            if (codiceCorsoEsistente != null)
            {
                return lezioniRepo.GetAll().Where(l=>l.Codice==codiceCorsoEsistente).ToList();

            }
            else
            {
                return null;
            }

        }

        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll().ToList();
        }

        public List<Studente> GetAllStudentiDiUnCorso(string codice)
        {
            return studentiRepo.GetStudentiByCorso(codice).ToList();
        }

        public Esito ModificaAulaLezione(int id, string? nuovaAula)
        {
            var lezioneEsistente = lezioniRepo.GetById(id);
            if (lezioneEsistente == null)
            {
                return new Esito { Messaggio = "id lezione non trovato", IsOk = false };
            }
            else
            {
                lezioneEsistente.Aula = nuovaAula;
                lezioniRepo.Update(lezioneEsistente);
                return new Esito { Messaggio = "aula modificata correttamente", IsOk = true };

            }
        }

        public Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione)
        {
            var corsoEsistente=corsiRepo.GetByCode(codice);
            if(corsoEsistente == null)
            {
                return new Esito { Messaggio = "codice non trovato", IsOk = false };


            }
            else
            {
                corsoEsistente.Nome= nuovoNome;
                corsoEsistente.Descrizione= nuovaDescrizione;
                corsiRepo.Update(corsoEsistente);
                return new Esito { Messaggio="corso modificato correttamente",IsOk=true};
            }
        }

        public Esito ModificaDocente(int id, string? nuovaEmail, string? nuovoTelefono)
        {
            var docenteEsistente = docentiRepo.GetById(id);
            if (docenteEsistente == null)
            {
                return new Esito { Messaggio = "id docente non trovato", IsOk = false };
            }
            else
            {
                docenteEsistente.Email = nuovaEmail;
                docenteEsistente.NumeroTelefono = nuovoTelefono;
                docentiRepo.Update(docenteEsistente);
                return new Esito { Messaggio = "email e numero di telefono modificati correttamente", IsOk = true };

            }
        }

        public Esito ModificaEmailStudente(int id,string? nuovaEmail)
        {
            var studenteEsistente = studentiRepo.GetById(id);
            if(studenteEsistente == null)
            {
                return new Esito { Messaggio="id studente non trovato", IsOk=false };
            }
            else
            {
                studenteEsistente.Email= nuovaEmail;
                studentiRepo.Update(studenteEsistente);
                return new Esito { Messaggio="email modificata correttamente", IsOk=true};  

            }
        }

        
    }
}
