namespace FileCSV_Scrittura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FileCSV_Scrittura!");

            string path = @"..\..\..\File\Persone.csv";

            var p = new Persona { Cognome = "Del Rio", Nome = "Diego", DataNascita = new DateTime(2000, 3, 15), LuogoNascita = "Torino", Sesso = TipoSesso.M };

            //scrittura su file csv
            using (StreamWriter sw = new StreamWriter(path)) 
            {
                sw.Write(p.FormatCSV());            
            
            }
            Console.WriteLine("Operazione avvenuta con successo!");





        }
    }
}
