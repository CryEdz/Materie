namespace Rubrica
{
    internal class Contatto
    {
        public string Cognome { get; }
        public string Nome { get; }
        public Indirizzo Indirizzo { get; }
        public string Telefono { get; }
        public string Email { get; }

        public Contatto(string cognome, string nome, Indirizzo indirizzo, string telefono, string email)
        {
            Cognome = cognome;
            Nome = nome;
            Indirizzo = indirizzo;
            Telefono = telefono;
            Email = email;
        }

        public Contatto(string cognome, string nome)
            : this(cognome, nome, new Indirizzo("Via non specificata", "00000", "Città non specificata", "XX"), "N/D", "N/D")
        {
        }

        public string GetSchedaCompleta()
        {
            return $"{Nome} {Cognome} - {Indirizzo} Tel. {Telefono} - email: {Email}";
        }
    }
}
