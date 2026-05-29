using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseEmail
{
    internal class Email
    {
        public string DA { get; set; }
        public string A { get; set; }
        public string BC { get; set; }=string.Empty;
        public string BCC { get; set; } = string.Empty;
        public string Oggetto { get; set; }
        public string Messaggio { get; set; }
        public DateTime? Data { get; set; } = DateTime.Now;
        public Priorita Priorita { get; set; } = Priorita.NORMALE;

        //costruttori
        //overloading
        public Email()
        {}

        public Email(string da, string a, string oggetto, string messaggio)
        {
            DA = da;
            A = a;
            Oggetto = oggetto;
            Messaggio = messaggio;
        }

        public Email(string dA, string a, string bC, string bCC, string oggetto, string messaggio, DateTime? data, Priorita priorita) 
            : this(dA, a, oggetto, messaggio)
        {
            BC = bC;
            BCC = bCC;
            Data = data;
            Priorita = priorita;
        }

        public override string ToString()
        {
            return $"{{" +
                $"{nameof(DA)}={DA}" +
                $", {nameof(A)}={A}" +
                $", {nameof(BC)}={BC}" +
                $", {nameof(BCC)}={BCC}" +
                $", {nameof(Oggetto)}={Oggetto}" +
                $", {nameof(Messaggio)}={Messaggio}" +
                $", {nameof(Data)}={Data.ToString()}" +
                $", {nameof(Priorita)}={Priorita.ToString()}" +
                $"}}";
        }
    }
}
