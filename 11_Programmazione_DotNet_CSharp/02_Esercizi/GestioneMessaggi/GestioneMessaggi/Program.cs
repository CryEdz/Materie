namespace GestioneMessaggi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestione Messaggi!");

            
            var lista = new List<Messaggio>
            {
                new Messaggio {Mittente="Mario Rossi",Destinatario="Laura Bianchi",Oggetto="Aggiornamento progetto",Testo="Il progetto procede secondo i tempi previsti.",DataOra=new DateTime(2025,1,15,10,30,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Anna Verdi",Destinatario="Mario Rossi",Oggetto="URGENTE: Problema in produzione",Testo="Riscontrato un blocco al server principale.",DataOra=new DateTime(2025,1,16,8,15,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Laura Bianchi",Destinatario="Anna Verdi",Oggetto="Buon compleanno!",Testo="Auguri di buon compleanno!",DataOra=new DateTime(2025,1,20,12,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Giuseppe Neri",Destinatario="Maria Gialli",Oggetto="Report vendite Q1",Testo="Allego il report del primo trimestre.",DataOra=new DateTime(2025,2,1,9,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Maria Gialli",Destinatario="Giuseppe Neri",Oggetto="RE: Report vendite Q1",Testo="Grazie, darò un'occhiata entro domani.",DataOra=new DateTime(2025,2,1,14,30,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Carlo Blu",Destinatario="Francesca Rosa",Oggetto="Fattura fornitore",Testo="La fattura 2025/001 è in scadenza il 15/03.",DataOra=new DateTime(2025,2,10,11,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Francesca Rosa",Destinatario="Carlo Blu",Oggetto="RE: Fattura fornitore",Testo="Provvedo al pagamento oggi pomeriggio.",DataOra=new DateTime(2025,2,10,15,45,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Paolo Viola",Destinatario="Ufficio Personale",Oggetto="Richiesta ferie",Testo="Richiedo 5 giorni di ferie dal 10 al 14 marzo.",DataOra=new DateTime(2025,2,20,8,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Ufficio Personale",Destinatario="Paolo Viola",Oggetto="RE: Richiesta ferie",Testo="Ferie approvate. Buona vacanza!",DataOra=new DateTime(2025,2,21,10,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Elena Marrone",Destinatario="Direzione",Oggetto="Nuovo cliente acquisito",Testo="Abbiamo firmato il contratto con la società Beta Srl.",DataOra=new DateTime(2025,3,1,16,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Direzione",Destinatario="Elena Marrone",Oggetto="RE: Nuovo cliente acquisito",Testo="Ottimo lavoro! Organizziamo una riunione di allineamento.",DataOra=new DateTime(2025,3,2,9,30,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Luca Argento",Destinatario="Tutti",Oggetto="Spegnimento server notturno",Testo="I server verranno spenti sabato dalle 22 alle 6 per manutenzione.",DataOra=new DateTime(2025,3,10,17,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Simona Bianco",Destinatario="Reparto IT",Oggetto="Assistenza stampante",Testo="La stampante del terzo piano non funziona.",DataOra=new DateTime(2025,3,12,11,30,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Reparto IT",Destinatario="Simona Bianco",Oggetto="RE: Assistenza stampante",Testo="Interverremo entro oggi pomeriggio.",DataOra=new DateTime(2025,3,12,13,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Marco Rossetti",Destinatario="Amministrazione",Oggetto="Rimborso spese viaggio",Testo="Allego la richiesta di rimborso per la trasferta a Milano.",DataOra=new DateTime(2025,3,20,10,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Amministrazione",Destinatario="Marco Rossetti",Oggetto="RE: Rimborso spese viaggio",Testo="Rimborso autorizzato, verrà accreditato in busta paga.",DataOra=new DateTime(2025,3,22,15,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Giorgio Ferri",Destinatario="Team Sviluppo",Oggetto="Nuova release 2.5",Testo="La release 2.5 è pronta per il deploy in produzione.",DataOra=new DateTime(2025,4,1,9,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Team Sviluppo",Destinatario="Giorgio Ferri",Oggetto="RE: Nuova release 2.5",Testo="Test superati. Procediamo con il deploy venerdì.",DataOra=new DateTime(2025,4,2,11,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Roberto Moretti",Destinatario="Marketing",Oggetto="Campagna pubblicitaria estiva",Testo="Proposta per la campagna social dei mesi estivi.",DataOra=new DateTime(2025,4,10,14,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Marketing",Destinatario="Roberto Moretti",Oggetto="RE: Campagna pubblicitaria estiva",Testo="Bella proposta! Approviamo il budget richiesto.",DataOra=new DateTime(2025,4,12,10,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Silvia Conti",Destinatario="HR",Oggetto="Candidatura interna",Testo="Mi candido per la posizione di Team Leader.",DataOra=new DateTime(2025,4,20,8,30,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="HR",Destinatario="Silvia Conti",Oggetto="RE: Candidatura interna",Testo="La sua candidatura è stata presa in carico.",DataOra=new DateTime(2025,4,22,12,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Davide Rizzi",Destinatario="Stefano Gallo",Oggetto="Documentazione API",Testo="Ho completato la documentazione delle nuove API REST.",DataOra=new DateTime(2025,5,2,16,30,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Stefano Gallo",Destinatario="Davide Rizzi",Oggetto="RE: Documentazione API",Testo="Perfetto, la carico sul wiki interno.",DataOra=new DateTime(2025,5,3,9,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Alessia Fiori",Destinatario="Tutti",Oggetto="Festa aziendale",Testo="La festa aziendale si terrà il 30 giugno presso Villa Belvedere.",DataOra=new DateTime(2025,5,10,11,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Claudio Sala",Destinatario="Direzione Vendite",Oggetto="Obiettivi semestrali",Testo="Gli obiettivi del primo semestre sono stati raggiunti all'85%.",DataOra=new DateTime(2025,6,1,10,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Direzione Vendite",Destinatario="Claudio Sala",Oggetto="RE: Obiettivi semestrali",Testo="Dobbiamo spingere per raggiungere il 100% entro giugno.",DataOra=new DateTime(2025,6,3,14,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Valentina Costa",Destinatario="Reparto Qualità",Oggetto="Non conformità lotto 1234",Testo="Rilevata non conformità sul lotto 1234 di produzione.",DataOra=new DateTime(2025,6,15,7,45,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Reparto Qualità",Destinatario="Valentina Costa",Oggetto="RE: Non conformità lotto 1234",Testo="Lotto bloccato. Avviata procedura di containment.",DataOra=new DateTime(2025,6,15,9,30,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Fabio Leone",Destinatario="Amministrazione",Oggetto="Buono pasto smarrito",Testo="Ho smarrito il tesserino dei buoni pasto, richiedo un duplicato.",DataOra=new DateTime(2025,6,20,8,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Amministrazione",Destinatario="Fabio Leone",Oggetto="RE: Buono pasto smarrito",Testo="Duplicato ordinato. Riceverà il nuovo tesserino in 5 giorni.",DataOra=new DateTime(2025,6,22,11,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Nicola Bianchi",Destinatario="IT Security",Oggetto="Tentativo di phishing",Testo="Ho ricevuto una mail sospetta con oggetto 'URGENTE: aggiorna password'.",DataOra=new DateTime(2025,7,1,10,15,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="IT Security",Destinatario="Tutti",Oggetto="ALLERTA: Campagna phishing in corso",Testo="Segnalata campagna phishing. Non cliccate su link sospetti.",DataOra=new DateTime(2025,7,1,11,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Marta Puglisi",Destinatario="Ufficio Acquisti",Oggetto="Richiesta materiale ufficio",Testo="Necessitiamo di 10 risme di carta e 20 penne.",DataOra=new DateTime(2025,7,10,9,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Ufficio Acquisti",Destinatario="Marta Puglisi",Oggetto="RE: Richiesta materiale ufficio",Testo="Ordine effettuato. Consegna prevista per venerdì.",DataOra=new DateTime(2025,7,11,15,30,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Alessandro Rinaldi",Destinatario="Team Progetti",Oggetto="Kick-off progetto Gamma",Testo="Riunione di kick-off il 15/07 alle 10 in sala riunioni.",DataOra=new DateTime(2025,7,5,16,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Team Progetti",Destinatario="Alessandro Rinaldi",Oggetto="RE: Kick-off progetto Gamma",Testo="Confermiamo presenza. Prepareremo la documentazione.",DataOra=new DateTime(2025,7,8,12,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Chiara Esposito",Destinatario="Direzione HR",Oggetto="Bilancio competenze",Testo="Allego il bilancio delle competenze del personale 2025.",DataOra=new DateTime(2025,7,20,14,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Direzione HR",Destinatario="Chiara Esposito",Oggetto="RE: Bilancio competenze",Testo="Documento ricevuto. Lo esamineremo in sede di programmazione.",DataOra=new DateTime(2025,7,22,10,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Enrico Sartori",Destinatario="Segreteria",Oggetto="Prenotazione sala per riunione",Testo="Vorrei prenotare la sala grande per il 5 agosto dalle 10 alle 12.",DataOra=new DateTime(2025,7,25,8,30,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Segreteria",Destinatario="Enrico Sartori",Oggetto="RE: Prenotazione sala per riunione",Testo="Sala prenotata. Le invierò la conferma via calendario.",DataOra=new DateTime(2025,7,25,10,0,0),Priorita=Priorita.Bassa},
                new Messaggio {Mittente="Luisa Ferrara",Destinatario="Reparto Logistica",Oggetto="Spedizione in ritardo",Testo="L'ordine 7890 risulta in ritardo di 3 giorni sulla consegna.",DataOra=new DateTime(2025,8,1,11,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Reparto Logistica",Destinatario="Luisa Ferrara",Oggetto="RE: Spedizione in ritardo",Testo="Problema con il corriere. Stiamo gestendo la situazione.",DataOra=new DateTime(2025,8,2,9,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Daniele Morelli",Destinatario="Tutti",Oggetto="Chiusura estiva uffici",Testo="Gli uffici rimarranno chiusi dal 12 al 26 agosto.",DataOra=new DateTime(2025,8,5,12,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Elisa Bernardi",Destinatario="Responsabile Formazione",Oggetto="Iscrizione corso Excel avanzato",Testo="Desidero iscrivermi al corso di Excel avanzato di settembre.",DataOra=new DateTime(2025,8,20,15,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Responsabile Formazione",Destinatario="Elisa Bernardi",Oggetto="RE: Iscrizione corso Excel avanzato",Testo="Iscrizione confermata. Il corso si terrà dal 15 al 18 settembre.",DataOra=new DateTime(2025,8,22,11,30,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Federico De Luca",Destinatario="Ufficio Legale",Oggetto="Revisione contratto fornitore",Testo="Invio in allegato il contratto del fornitore da revisionare.",DataOra=new DateTime(2025,9,1,9,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Ufficio Legale",Destinatario="Federico De Luca",Oggetto="RE: Revisione contratto fornitore",Testo="Revisione completata. Ho evidenziato alcune clausole da modificare.",DataOra=new DateTime(2025,9,5,17,0,0),Priorita=Priorita.Alta},
                new Messaggio {Mittente="Giulia Marchetti",Destinatario="Laboratorio IT",Oggetto="Richiesta nuovo notebook",Testo="Il mio notebook attuale ha dei problemi di performance. Richiedo sostituzione.",DataOra=new DateTime(2025,9,10,10,0,0),Priorita=Priorita.Normale},
                new Messaggio {Mittente="Laboratorio IT",Destinatario="Giulia Marchetti",Oggetto="RE: Richiesta nuovo notebook",Testo="Richiesta approvata. Il nuovo notebook sarà disponibile la prossima settimana.",DataOra=new DateTime(2025,9,12,14,0,0),Priorita=Priorita.Normale}
            };
            var biz = new MessaggiBiz();
            biz.Elenco = lista;

            var menu = "\nScegli una tra le seguenti operazioni:" +
                "\n0 - Termina il programma" +
                "\n1 - Inserisci un nuovo messaggio" +
                "\n2 - Cerca messaggi per mittente" +
                "\n3 - Cerca messaggi per destinatario" +
                "\n4 - Conta messaggi dopo una certa data" +
                "\n5 - Visualizza elenco messaggi" +
                "\n\nScegli: ";
            int scelta = -1;

            do
            {
                Console.Write(menu);
                scelta = int.Parse(Console.ReadLine()!);

                switch (scelta)
                {
                    case 0: Console.WriteLine("Programma terminato"); break;
                    case 1: biz.Inserisci(MessaggiBiz.NuovoMessaggioDaInput()); Console.WriteLine("Messaggio inserito."); break;
                    case 2:
                        Console.Write("Mittente da cercare: ");
                        Console.WriteLine(string.Join('\n', biz.CercaPerMittente(Console.ReadLine()!)));
                        break;
                    case 3:
                        Console.Write("Destinatario da cercare: ");
                        Console.WriteLine(string.Join('\n', biz.CercaPerDestinatario(Console.ReadLine()!)));
                        break;
                    case 4:
                        Console.Write("Data (gg/mm/aaaa): ");
                        var data = DateTime.Parse(Console.ReadLine()!);
                        Console.WriteLine("Messaggi dopo il " + data.ToShortDateString() + ": " + biz.ContaDopoData(data));
                        break;
                    case 5: Console.WriteLine(biz.StampaElenco()); break;
                    default: Console.WriteLine("Scelta errata!"); break;
                }

                Console.Write("Premi un tasto per continuare ...");
                Console.ReadLine();
                Console.Clear();

            } while (scelta != 0);
        }
    }
}
