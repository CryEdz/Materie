using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneMessaggi
{
    public class MessaggiBiz
    {
        public List<Messaggio> Elenco { get; set; }

        public MessaggiBiz()
        {
            Elenco = new List<Messaggio>();
        }

        public void Inserisci(Messaggio m)
        {
            Elenco.Add(m);
        }

        public List<Messaggio> CercaPerMittente(string mittente)
        {
            var risultati = new List<Messaggio>();
            foreach (var m in Elenco)
                if (m.Mittente != null && m.Mittente.Contains(mittente, StringComparison.OrdinalIgnoreCase))
                    risultati.Add(m);
            return risultati;
        }

        public List<Messaggio> CercaPerDestinatario(string destinatario)
        {
            var risultati = new List<Messaggio>();
            foreach (var m in Elenco)
                if (m.Destinatario != null && m.Destinatario.Contains(destinatario, StringComparison.OrdinalIgnoreCase))
                    risultati.Add(m);
            return risultati;
        }

        public int ContaDopoData(DateTime data)
        {
            int count = 0;
            foreach (var m in Elenco)
                if (m.DataOra > data)
                    count++;
            return count;
        }

        public string StampaElenco()
        {
            return string.Join("\n", Elenco);
        }

        public  Messaggio NuovoMessaggioDaInput()
        {
            var m = new Messaggio();
            Console.Write("Mittente: ");
            m.Mittente = Console.ReadLine();
            Console.Write("Destinatario: ");
            m.Destinatario = Console.ReadLine();
            Console.Write("Oggetto: ");
            m.Oggetto = Console.ReadLine();
            Console.Write("Testo: ");
            m.Testo = Console.ReadLine();
            m.DataOra = DateTime.Now;
            Console.Write("Priorità (0=Bassa, 1=Normale, 2=Alta): ");
            m.Priorita = (Priorita)int.Parse(Console.ReadLine()!);
            return m;
        }
    }
}
