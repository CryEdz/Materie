using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneMessaggi
{
    public enum Priorita
    {
        Bassa,
        Normale,
        Alta
    }

    public class Messaggio
    {
        public string? Mittente { get; set; }
        public string? Destinatario { get; set; }
        public string? Oggetto { get; set; }
        public string? Testo { get; set; }
        public DateTime DataOra { get; set; }
        public Priorita Priorita { get; set; }

        public override string ToString()
        {
            return $"{nameof(Mittente)}={Mittente}, {nameof(Destinatario)}={Destinatario}, {nameof(Oggetto)}={Oggetto}, {nameof(DataOra)}={DataOra}, {nameof(Priorita)}={Priorita}";
        }
    }
}
