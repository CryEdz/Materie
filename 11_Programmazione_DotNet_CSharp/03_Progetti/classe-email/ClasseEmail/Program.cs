/*
 Si consideri di voler gestire un email. Sono richiesti i seguenti dati: DA, A, CC, BCC, Oggetto, Messaggio, Data (default), Priorità  con i valori: BASSA, NORMALE (default) o ALTA. Si ipotizzi che nei campi DA, A, CC e BCC si possa inserire solo un indirizzo email.

Implementare il metodo ToString

Si richiede di creare tre istanze, assegnando per ognuna una priorità differente.
*/

namespace ClasseEmail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailBassa = new Email("mittente1@example.com", "destinatario1@example.com", "Promozione", "Messaggio con priorità bassa")
            {
                Priorita = PrioritaEmail.Bassa
            };
             
            var emailNormale = new Email("mittente2@example.com", "destinatario2@example.com", "Aggiornamento", "Messaggio con priorità normale")
            {
                Cc = "copia@example.com"
            };
             
            var emailAlta = new Email("mittente3@example.com", "destinatario3@example.com", "Urgenza", "Messaggio con priorità alta")
            {
                Bcc = "nascosta@example.com",
                Priorita = PrioritaEmail.Alta
            };

            Console.WriteLine(emailBassa);
            Console.WriteLine();
            Console.WriteLine(emailNormale);
            Console.WriteLine();
            Console.WriteLine(emailAlta);
        }
    }
}
