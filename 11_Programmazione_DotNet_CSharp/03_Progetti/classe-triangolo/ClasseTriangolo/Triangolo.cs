using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseTriangolo
{
    internal class Triangolo
    {
        //attributi
        private double lato1;

        public double Lato1
        {
            get { return lato1; }
            set { lato1 = value; }
        }

        private double lato2;

        public double Lato2
        {
            get { return lato2; }
            set { lato2 = value; }
        }

        private double lato3;

        public double Lato3
        {
            get { return lato3; }
            set { lato3 = value; }
        }
        //costruttore
        //metodo speciale, serve per costruire oggetti
        //specifica come vanno costruiti gli oggetti

        //costruttore di default
       /* public Triangolo(){
            if (!IsCostruibile())
            {
                throw new Exception("Impossibile costruire il triangolo");
            }
        }
       */
        //Costruttore con passaggio dei parametri
        //Il costruttore di default è stato sovrascritto, sostituito
        public Triangolo(double lato1, double lato2, double lato3)
        {
            this.lato1 = lato1;
            this.lato2 = lato2;
            this.lato3 = lato3;
            if (!IsCostruibile())
            {
                throw new Exception("Impossibile costruire il triangolo");
            }
        }



        //metodi

        private bool IsCostruibile()
        {
            return Lato1 +Lato2 > Lato3 && Lato1 + Lato3 > Lato2 && Lato2 + Lato3 > Lato1;
        }

        public double Perimetro()
        {
            return lato1 + lato2 + lato3;
        }

        public double Area()
        {
            if (!IsCostruibile())
            {
                throw new Exception("Impossibile costruire il triangolo");
            }

                double p = Perimetro() / 2;
            return Math.Sqrt(p * (p - lato1) * (p - lato2) * (p - lato3));
        }

        public string Tipo()
        {

            if (Lato1 == Lato2 && Lato1 == Lato3)
                return "Equilatero";
            else if (Lato1 == Lato2 || Lato1 == Lato3 || Lato2 == Lato3)
                return "Isoscele";
            else
                return "Scaleno";

        }

        //metodi usa e getta 
        public string FormatLineare() 
        {
            return $"" +
        $"Lato1 = {Lato1}" +
        $", Lato2 = {Lato2}" +
        $", Lato3 = {Lato3}" +
        $", Perimetro = {Perimetro()}" +
        $", Area = {Area()}" +
        $", Tipo = {Tipo()}"
        ;
        }

        public string FormatDettaglio() {
        return $"" +
        $"\nLato1 = {Lato1}" +
        $"\nLato2 = {Lato2}" +
        $"\nLato3 = {Lato3}" +
        $"\nPerimetro = {Perimetro()}" +
        $"\nArea = {Area()}" +
        $"\nTipo = {Tipo()}"
        ;
        }


    }
}
