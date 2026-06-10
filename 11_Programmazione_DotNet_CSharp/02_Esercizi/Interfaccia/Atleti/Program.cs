using System;
using System.Collections.Generic;
using System.Text;

namespace Atleti
{
    public class Program
    {
        public static void Main(string[] args)
        {


            Console.WriteLine("Interfaccie!");


            var a1 =new Atleta { Nome="Piero", Cognome="Paoletti", Pettorina = 123, Disciplina = "Lancio del peso" };
            Console.WriteLine(a1);
            Console.WriteLine(a1.Dorso());
            
            var c1 = new Calciatore { Nome = "Pino", Cognome = "Del Pino", Pettorina = 7, Disciplina = "Calcio", GoalSegnati = 5, PartiteGiocate = 6 };
            Console.WriteLine(c1);

            Calciatore c2 = (Calciatore)c1.Clone();
            c2.Cognome = "Del Cotto";
            c2.Nome = "Davide";
            c2.GoalSegnati = 3;
            Console.WriteLine(c2);

            //Classifica
            Console.WriteLine("\nClassifica:");
            if (c1.CompareTo(c2) ==1)
                Console.WriteLine($"1. {c1.Cognome}\n2. {c2.Cognome}");
            else if (c1.CompareTo(c2) == -1)
                Console.WriteLine($"1. {c2.Cognome}\n2. {c1.Cognome}");
        }
    }
}