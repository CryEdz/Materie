namespace FileTesto_Scrittura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FileTesto-Scrittura!");

            string path = @"..\..\..\File\testo.txt";

            Console.Write("Inserisci una frase:");
            string frase = Console.ReadLine();

            //accesso al file nomodalità scrittura 
            StreamWriter sw = new StreamWriter(path);

            //scrivo su file di testo
            sw.WriteLine(frase);

            //salva tutto e rilascia la risorsa
            sw.Close();

            Console.WriteLine("Operazione avvenuta con successo!");



        }
    }
}
