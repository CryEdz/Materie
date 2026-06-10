using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;

namespace FileCSV_Lettura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FileCSV_Lettura!");

            string path = @"..\..\..\File\Persone.csv";

            //acceso al file in modalita lettura

            string txt;
            using (StreamReader sr = new StreamReader(path))
            {
                txt = sr.ReadToEnd();
            }

            string[] righe = txt.Split('\n');

            List<Persona> elenco = new List<Persona>();
            for (int i = 0; i < righe.Length; i++)
            {
                string[] dati = righe[i].Split(";");
                elenco.Add(
                    new Persona { Nome = dati[0], Cognome = dati[1], DataNascita = DateTime.Parse(dati[2]), LuogoNascita = dati[3], Sesso = dati[4].Equals("M") ? TipoSesso.M : TipoSesso.F }
                    );
            }
            foreach (Persona persona in elenco)
            {
                Console.WriteLine(persona);
                Console.WriteLine($"Eta: {persona.Eta()}");
            }
        }
    }
}
