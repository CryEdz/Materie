namespace ClasseEmail
{
    public enum PrioritaEmail
    {
        Bassa,
        Normale,
        Alta
    }

    public class Email
    {
        public string Da { get; set; }
        public string A { get; set; }
        public string Cc { get; set; } = string.Empty;
        public string Bcc { get; set; } = string.Empty;
        public string Oggetto { get; set; }
        public string Messaggio { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public PrioritaEmail Priorita { get; set; } = PrioritaEmail.Normale;
         
        public Email(string da, string a, string oggetto, string messaggio)
        {
            Da = da;
            A = a;
            Oggetto = oggetto;
            Messaggio = messaggio;
        }

        public Email(string da, string a, string oggetto, string messaggio, PrioritaEmail priorita)
            : this(da, a, oggetto, messaggio)
        {
            Priorita = priorita;
        }

        public override string ToString()
        {
            return $"{{{nameof(Da)}={Da}, {nameof(A)}={A}, {nameof(Cc)}={Cc}, {nameof(Bcc)}={Bcc}, {nameof(Oggetto)}={Oggetto}, {nameof(Messaggio)}={Messaggio}, {nameof(Data)}={Data.ToString()}, {nameof(Priorita)}={Priorita.ToString()}}}";
        }
    }
}