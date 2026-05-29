using System.Drawing;
using System.Security.Cryptography;

namespace ClasseTriangolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanza Triangolo!");
            var t1= new Triangolo(3, 4, 5);

            string msg = $"" +
                $"Lato1 = {t1.Lato1}" +
                $", Lato2 = {t1.Lato2}" +
                $", Lato3 = {t1.Lato3}" +
                $", Perimetro = {t1.Perimetro()}" +
                $", Area = {t1.Area()}" +
                $", Tipo = {t1.Tipo()}"
                ;
            Console.WriteLine(msg);

            var t2 = new Triangolo(3.5, 4, 5) ;

             msg = $"" +
                $"Lato1 = {t2.Lato1}" +
                $", Lato2 = {t2.Lato2}" +
                $", Lato3 = {t2.Lato3}" +
                $", Perimetro = {t2.Perimetro()}" +
                $", Area = {t2.Area()}" +
                $", Tipo = {t2.Tipo()}"
                ;
            Console.WriteLine(msg);

            var t3 = new Triangolo(3, 4, 5);
            Console.WriteLine(t3.FormatDettaglio());
            
        }
    }
}
