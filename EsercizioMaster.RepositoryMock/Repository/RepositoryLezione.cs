using EsercizioMaster.Core.IRepository;
using EsercizioMaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioMaster.RepositoryMock.Repository
{
    public class RepositoryLezione : IRepositoryLezione
    {

        public static List<Lezione> lezioni = new List<Lezione>()
        {
            new Lezione{LezioneId=1,DataOraInizio=new DateTime(2022,01,18,10,00,00),Durata=30,Aula="Magna",Codice="C-01",DocenteId=1},
            new Lezione{LezioneId=2,DataOraInizio=new DateTime(2022,01,19,14,30,00),Durata=10,Aula="aula informatica",Codice="C-01",DocenteId=2}

        };
        public Lezione Add(Lezione item)
        {
            lezioni.Add(item);
            return item;
        }

        public bool Delete(Lezione item)
        {
            lezioni.Remove(item);
            return true;
        }

        public ICollection<Lezione> GetAll()
        {
            return lezioni;
        }

        public Lezione GetById(int id)
        {
            return lezioni.FirstOrDefault(l=>l.LezioneId == id);
        }

        public ICollection<Lezione> GetLezioniByCoodiceCorso(string codice)
        {
            return lezioni.Where(l=>l.Codice==codice).ToList();
        }

        public ICollection<Lezione> GetLezioniByNomeCorso(string codice)
        {
            return GetAll().Where(l => l.Codice == codice).ToList();
        }

        public Lezione Update(Lezione item)
        {
            foreach(var l in lezioni)
            {
                if (l.LezioneId == item.LezioneId)
                {
                    l.Aula = item.Aula;
                    return l;
                }
            }
            return null;
        }
    }
}
