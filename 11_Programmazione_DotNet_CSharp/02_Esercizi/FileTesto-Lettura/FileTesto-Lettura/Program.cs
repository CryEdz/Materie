namespace FileTesto_Lettura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FileTesto-Lettura!");
            
            string path = @"..\..\..\File\testo.txt";

            //accesso al file di testo in modalità lettura
            StreamReader sr = new StreamReader(path);

            string txt =sr.ReadToEnd();

            sr.Close(); //chiudi accesso al file

            Console.WriteLine("Lettura del file testo.txt avvenuta correttamente");
            Console.WriteLine($"Testo recuperato: {txt}");

        }
    }
}
