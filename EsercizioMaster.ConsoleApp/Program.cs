// See https://aka.ms/new-console-template for more information
using EsercizioMaster.ConsoleApp;
using EsercizioMaster.Core.Business_Layer;
using EsercizioMaster.Core.Models;
using EsercizioMaster.RepositoryEF.RepositoryEF;
using EsercizioMaster.RepositoryMock.Repository;

Console.WriteLine("Hello, World!");
//per far comunicare tra loro i 3 progetti con Repository Mock:
IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorso(), new RepositoryStudente(), new RepositoryDocente(),new RepositoryLezione());
//se invece utilizzo le EF
//IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsoEF(), new RepositoryStudenteEF(), new RepositoryDocenteEF(), new RepositoryLezioneEF());
bool continua = true;
while (continua)
{
    int scelta = Menu();
    continua= AnalizzaScelta(scelta);

}

bool AnalizzaScelta(int scelta)
{
    switch (scelta)
    {
        case 1:
            VisualizzaCorsi();
            break;
        case 2:
            InserisciCorso();
            break;
        case 3:
            ModificaCorso();
            break;
        case 4:
            EliminaCorso();
            break;
        case 5:
            VisualizzaStudenti();
            break;
        case 6:
            InserisciStudente();
            break;
        case 7:
            ModificaStudente();
            break;
        case 8:
            EliminaStudente();
            break;
        case 9:
            VisualizzaStudentiDiUnCorso();
            break;
        case 10:
            VisualizzaDocenti();
            break;
        case 11:
            InserisciDocente();
            break;
        case 12:
            ModificaDocente();
            break;
        case 13:
            EliminaDocente();
            break;
        case 14:
            VisualizzaLezioni();
            break;
        case 15:
            InserisciLezione();
            break;
        case 16:
            ModificaLezione();
            break;
        case 17:
            EliminaLezione();
            break;
        case 18:
            VisualizzaLezioniByCodice();
            break;
        case 19:
            VisualizzaLezioniByNome();
            break;

        case 0:
            return false;
            
        //default:
        //    break;
    }
    return true;
}

void VisualizzaLezioniByNome()
{
    //recupera lista dei corsi
    Console.WriteLine("scegli il nome di quale corso visualizzare le lezioni");
    VisualizzaCorsi();
    string nome = Console.ReadLine();
    List<Lezione> listaLezioni = bl.GetAllLezioniByNomeCorso(nome);

    //stampa la lista
    if (listaLezioni == null)
    {
        Console.WriteLine("non esiste nessun corso con quel nome");
    }
    else if (listaLezioni.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaLezioni)
        {
            Console.WriteLine(item);
        }
    }
}

void VisualizzaLezioniByCodice()
{
    //recupera lista dei corsi
    Console.WriteLine("scegli il codice di quale corso visualizzare le lezioni");
    VisualizzaCorsi();
    string codice = Console.ReadLine();
    List<Lezione> listaLezioni = bl.GetAllLezioniByCodiceCorso(codice);

    //stampa la lista
    if (listaLezioni.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaLezioni)
        {
            Console.WriteLine(item);
        }
    }
}

void EliminaLezione()
{
    VisualizzaLezioni();
    Console.WriteLine("inserisci id della lezione da eliminare");
    int id = int.Parse(Console.ReadLine());

    Esito esito = bl.DeleteLezione(id);
    Console.WriteLine(esito.Messaggio);
}

void ModificaLezione()
{
    Console.WriteLine("elenco lezioni: ");
    VisualizzaLezioni();
    Console.WriteLine("quale lezione vuoi modificare? inserisci id ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("inserisci nuova aula");
    string nuovaAula = Console.ReadLine();
    



    Esito esito = bl.ModificaAulaLezione(id, nuovaAula);
    Console.WriteLine(esito.Messaggio);
}

void InserisciLezione()
{
    //chiedo all'utente i dati per creare nuovo studente 
    //Console.WriteLine("inserisci id della lezione");
    //int id = int.Parse(Console.ReadLine());
    //Console.WriteLine("inserisci data e ora inizio lezione");
    DateTime dataEora = Helper.CheckData("data e ora di inizio lezione");
    //Console.WriteLine("inserisci aula della lezione");
    string aula = Helper.CheckStringa("aula");
    //Console.WriteLine("inserisci durata in giorni");
    int durata = Helper.CheckIntero("durata in giorni");
    //Console.WriteLine("inserisci codice del corso");
    VisualizzaCorsi();
    string cod = Helper.CheckStringa("codice del corso");
    //Console.WriteLine("inserisci id docente della lezione");
    VisualizzaDocenti();
    int idDocente = Helper.CheckIntero("id Docente");

    

    Lezione nuovaLezione = new Lezione();
    //nuovaLezione.LezioneId = id;
    nuovaLezione.DataOraInizio = dataEora;
    nuovaLezione.Durata = durata;
    nuovaLezione.Aula = aula;
    nuovaLezione.Codice = cod;
    nuovaLezione.DocenteId = idDocente;

    Esito esito = bl.AddNuovaLezione(nuovaLezione);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzaLezioni()
{
    //recupera lista delle lezioni
    List<Lezione> listaLezioni = bl.GetAllLezioni();

    //stampa la lista
    if (listaLezioni.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaLezioni)
        {
            Console.WriteLine(item);
        }
    }
}

void EliminaDocente()
{

    VisualizzaDocenti();
    Console.WriteLine("inserisci id del docente da eliminare");
    int id = int.Parse(Console.ReadLine());

    Esito esito = bl.DeleteDocente(id);
    Console.WriteLine(esito.Messaggio);
}

void ModificaDocente()
{
    Console.WriteLine("elenco docenti: ");
    VisualizzaDocenti();
    Console.WriteLine("quale docente vuoi modificare? inserisci id ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("inserisci nuova email");
    string nuovaEmail = Console.ReadLine();
    Console.WriteLine("inserisci nuovo telefono");
    string nuovoTelefono = Console.ReadLine();



    Esito esito = bl.ModificaDocente(id, nuovaEmail, nuovoTelefono);
    Console.WriteLine(esito.Messaggio);
}

void InserisciDocente()
{
    //chiedo all'utente i dati per creare nuovo studente 
    //Console.WriteLine("inserisci id del docente");
    //int id = int.Parse(Console.ReadLine());
    //Console.WriteLine("inserisci il nome del docente");
    string nome = Helper.CheckStringa("nome");
    
    //Console.WriteLine("inserisci il cognome del docente");
    string cognome = Helper.CheckStringa("cognome");
    //Console.WriteLine("inserisci la mail");
    string mail = Helper.CheckStringa("email");
    
    //Console.WriteLine("inserisci il numero di telefono ");
    string numero = Helper.CheckStringa("numero di telefono");

    Docente nuovoDocente = new Docente();
    //nuovoDocente.Id = id;
    nuovoDocente.Nome = nome;
    nuovoDocente.Cognome = cognome;
    nuovoDocente.Email = mail;

    nuovoDocente.NumeroTelefono = numero;

    Esito esito = bl.AddNuovoDocente(nuovoDocente);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzaDocenti()
{
    //recupera lista dei docenti
    List<Docente> listaDocenti = bl.GetAllDocenti();

    //stampa la lista
    if (listaDocenti.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaDocenti)
        {
            Console.WriteLine(item);
        }
    }
}

void VisualizzaStudentiDiUnCorso()
{
    //recupera lista dei corsi
    Console.WriteLine("scegli il codice di quale corso visualizzare gli studenti");
    VisualizzaCorsi();
    string codice=Console.ReadLine();
    List<Studente> listaStudenti = bl.GetAllStudentiDiUnCorso(codice);

    //stampa la lista
    if (listaStudenti.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaStudenti)
        {
            Console.WriteLine(item);
        }
    }
}

void EliminaStudente()
{
    VisualizzaStudenti();
    Console.WriteLine("inserisci id dello studente da eliminare");
    int id = int.Parse(Console.ReadLine());

    Esito esito = bl.DeleteStudente(id);
    Console.WriteLine(esito.Messaggio);
}

void ModificaStudente()
{
    Console.WriteLine("elenco studenti: ");
    VisualizzaStudenti();
    Console.WriteLine("quale studente vuoi modificare? inserisci id ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("inserisci nuova email");
    string nuovaEmail = Console.ReadLine();
    

    Esito esito = bl.ModificaEmailStudente(id,nuovaEmail);
    Console.WriteLine(esito.Messaggio);
}

void InserisciStudente()
{
    //chiedo all'utente i dati per creare nuovo studente 
    //Console.WriteLine("inserisci id dello studente");
    //int id = int.Parse(Console.ReadLine());
    //Console.WriteLine("inserisci il nome dello studente");
    string nome = Helper.CheckStringa("nome studente");
    //Console.WriteLine("inserisci il cognome dello studente");
    string cognome = Helper.CheckStringa("cognome studente");
    //Console.WriteLine("inserisci la mail");
    string mail = Helper.CheckStringa("email studente");
    //Console.WriteLine("inserisci la data di nascita");
    DateTime data = Helper.CheckData("data di nascita dello studente");
    //Console.WriteLine("inserisci il titolo di studio ");
    string titolo = Helper.CheckStringa("titolo di studio dello studente");
    //Console.WriteLine("inserisci codice corso tra quelli visualizzati");
    VisualizzaCorsi();
    string cod= Helper.CheckStringa("codice corso");

    Studente nuovoStudente = new Studente();
    //nuovoStudente.Id = id;
    nuovoStudente.Nome = nome;
    nuovoStudente.Cognome = cognome;
    nuovoStudente.Email = mail;
    nuovoStudente.DataNascita = data;
    nuovoStudente.TitoloStudio = titolo;
    nuovoStudente.Codice = cod;

    Esito esito = bl.AddNuovoStudente(nuovoStudente);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzaStudenti()
{
    //recupera lista degli studenti
    List<Studente> listaStudenti = bl.GetAllStudenti();

    //stampa la lista
    if (listaStudenti.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaStudenti)
        {
            Console.WriteLine(item);
        }
    }
}

void EliminaCorso()
{
    VisualizzaCorsi();
    //Console.WriteLine("inserisci codice del corso da eliminare");
    string codice=Helper.CheckStringa("codice del corso da eliminare");

    Esito esito = bl.DeleteCorso(codice);
    Console.WriteLine(esito.Messaggio);
}

void ModificaCorso()
{
    Console.WriteLine("elenco corsi: ");
    VisualizzaCorsi();
    Console.WriteLine("quale corso vuoi modificare?  ");
    string codice=Helper.CheckStringa("codice corso");
    //Console.WriteLine("inserisci nuovo nome");
    string nuovoNome = Helper.CheckStringa("nuovo nome");
    //Console.WriteLine("inserisci nuova descrizione");
    string nuovaDescrizione = Helper.CheckStringa("nuova descrizione");

    Esito esito=bl.ModificaCorso(codice,nuovoNome, nuovaDescrizione);
    Console.WriteLine(esito.Messaggio);
}

void InserisciCorso()
{
    //chiedo all'utente i dati per creare nuovo corso 
    //Console.WriteLine("inserisci il codice del corso");
    string cod = Helper.CheckStringa("codice corso");
    //Console.WriteLine("inserisci il nome del corso");
    string nome = Helper.CheckStringa("nome del corso");
    //Console.WriteLine("inserisci la descrizione del corso");
    string desc = Helper.CheckStringa("descrizione del corso ");

    Corso nuovoCorso = new Corso();
    nuovoCorso.Codice = cod;
    nuovoCorso.Nome = nome;
    nuovoCorso.Descrizione = desc;

    Esito esito = bl.AddNuovoCorso(nuovoCorso);
    Console.WriteLine(esito.Messaggio);

}

void VisualizzaCorsi()
{
    //recupera lista dei corsi
    List<Corso> listaCorsi = bl.GetAllCorsi();
    
    //stampa la lista
    if(listaCorsi.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaCorsi)
        {
            Console.WriteLine(item);
        }
    }
    


}

int Menu()
{
    Console.WriteLine("**********************");
    Console.WriteLine("Menù");
    Console.WriteLine("\n Funzionalità corsi");
    Console.WriteLine("\n[1] visualizza corsi"+
        "\n[2] inserire nuovo corso"+
        "\n[3] modificare un corso"+
        "\n[4] eliminare un corso");
    Console.WriteLine("\n Funzionalità Studenti");
    Console.WriteLine("\n[5] visualizza elenco completo Studenti" +
        "\n[6] inserire nuovo studente" +
        "\n[7] modificare email di uno studente" +
        "\n[8] eliminare uno studente"+
        "\n[9] visualizza elenco studenti iscritti ad un corso");
    Console.WriteLine("\n Funzionalità Docenti");
    Console.WriteLine("\n[10] visualizza elenco completo Docenti" +
        "\n[11] inserire nuovo docente" +
        "\n[12] modificare email e telefono di un docente" +
        "\n[13] eliminare un docente");
    Console.WriteLine("\n Funzionalità Lezioni");
    Console.WriteLine("\n[14] visualizza elenco completo Lezioni" +
        "\n[15] inserire nuova lezione" +
        "\n[16] modificare aula di una lezione" +
        "\n[17] eliminare una lezione" +
        "\n[18] visualizza elenco lezioni di un corso per codice"+
        "\n[19] visualizza elenzo lezioni di un corso per nome");
    Console.WriteLine("\n [0] esci");
    Console.WriteLine("**********************");

    int scelta;
    Console.WriteLine("inserisci la tua scelta");
    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta>=0 && scelta <= 19))
    {
        Console.WriteLine("scelta errata!! Inserisci un numero compreso tra 0 e 19 ");
    }
    return scelta;

}