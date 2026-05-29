namespace Rubrica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatto contattoCompleto = new Contatto(
                "Rossi",
                "Mario",
                new Indirizzo("Via Trento 28", "10100", "Torino", "TO"),
                "011-4329512",
                "RossiM@tuttoweb.it");

            Contatto contattoParziale = new Contatto("Bianchi", "Luca");

            Console.WriteLine(contattoCompleto.GetSchedaCompleta());
            Console.WriteLine(contattoParziale.GetSchedaCompleta());
        }
    }
}
 