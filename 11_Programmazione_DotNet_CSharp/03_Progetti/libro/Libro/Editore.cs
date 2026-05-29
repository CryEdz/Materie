namespace LibroAutoriEditore
{
    public class Editore
    {
        public string? RagioneSociale { get; set; }
        public Indirizzo? Indirizzo { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? SitoWeb { get; set; }

        public override string ToString()
        {
            return $"Ragione Sociale: {RagioneSociale}" +
                $"\nIndirizzo: {Indirizzo}" +
                $"\nTelefono: {Telefono}" +
                $"\nEmail: {Email}" +
                $"\nSito Web: {SitoWeb}";
        }
    }
}