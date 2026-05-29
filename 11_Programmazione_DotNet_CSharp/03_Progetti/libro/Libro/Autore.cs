namespace LibroAutoriEditore
{
    public class Autore
    {
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string? Email { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }

        public string Nominativo()
        {
            //es. N. Cognome
            return Nome.Substring(0, 1).ToUpper() + ". " + Cognome.Substring(0, 1).ToUpper() + Cognome.Substring(1).ToLower();
        }

        public override string ToString()
        {
            return $"Nome: {Nome}" +
                $"\nCognome: {Cognome}" +
                $"\nEmail: {Email}" +
                $"\nInstagram: {Instagram}" +
                $"\nFacebook: {Facebook}";
        }

    }
}