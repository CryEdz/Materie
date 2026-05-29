namespace TesseraSanitaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanze di oggetti di tipo TesseraSanitaria!");
             
            ClasseTesseraSanitaria.TesseraSanitaria ts1 = new ClasseTesseraSanitaria.TesseraSanitaria("10000000000000000000", "QRGDRD96T22D208X", "Rossi", "Mario", "Torino", "TO", new DateTime(1996, 12, 22), ClasseTesseraSanitaria.Sesso.M, new DateTime(2026, 12, 22), "SSN-MIN 1000000000");

            Console.WriteLine(ts1);
            if (ts1.IsInScadenza())
            {
                Console.WriteLine("La tessera sanitaria è in scadenza!");
            }

            if (ts1.IsScaduta())
            {

                Console.WriteLine("La tessera sanitaria è scaduta!");
            }
            else
            {
                Console.WriteLine("La tessera sanitaria non è scaduta!");
            }
        }
    }
}
