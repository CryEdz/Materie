namespace ClasseEmail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanze di Email");


            var e1 = new Email
            {
                DA = "pino@its.net",
                A = "lino@its.net",
                Oggetto = "Saluti",
                Messaggio = "Ciao",
                Priorita = Priorita.BASSA
            };
            var e2 = new Email
            {
                DA = "pino@its.net",
                A = "lino@its.net",
                Oggetto = "Saluti",
                Messaggio = "Ciao",
                Priorita = Priorita.NORMALE
            };
            var e3 = new Email
            {
                DA = "pino@its.net",
                A = "lino@its.net",
                Oggetto = "Saluti",
                Messaggio = "Ciao",
                Priorita = Priorita.ALTA
            };
            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);

        }
    }
}
