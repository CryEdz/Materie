using System;
using System.Collections.Generic;
using System.Text;

namespace Atleti
{
    internal class Calciatore:Atleta, ICloneable, IComparable<Calciatore>
    {
        //propietà
        public int PartiteGiocate { get; set; }
        public int GoalSegnati { get; set; }

        public object Clone()
        {
            if (PartiteGiocate == 0)
                throw new Exception("Oggetto non clonato");

            return this.MemberwiseClone();
        }
        //CompareTo
        //  1 => se this è maggiore di other
        // -1 => se this è minore di other
        //  0 => se this è uguale a other

        public int CompareTo(Calciatore? other)
        {
            if (other != null)              {
         
            if (this.MediaGoalSegnati() > other.MediaGoalSegnati())
                return 1;
            else if (this.MediaGoalSegnati() < other.MediaGoalSegnati())
                return -1;
        }
        return 0;
        }
        public override bool Equals(object? obj)
        {
            return obj is Calciatore calciatore &&
                   Nome == calciatore.Nome &&
                   Cognome == calciatore.Cognome &&
                   Pettorina == calciatore.Pettorina &&
                   Disciplina == calciatore.Disciplina &&
                   PartiteGiocate == calciatore.PartiteGiocate &&
                   GoalSegnati == calciatore.GoalSegnati;
        }

        public double MediaGoalSegnati() { 
        
            return (double)GoalSegnati / PartiteGiocate;
        }
         

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $", {nameof(PartiteGiocate)} = {PartiteGiocate.ToString()}" +
                $", {nameof(GoalSegnati)} = {GoalSegnati.ToString()}" +
                $", Media Goal Segnati = {MediaGoalSegnati()}";
        }
    }
}
