namespace LibroAutoriEditore
{
    public class Indirizzo
    {
        public string? Via { get; set; }
        public string? Cap { get; set; }
        public string? Citta { get; set; }
        public string? Provincia { get; set; }

        public override string ToString()
        {
            return $"{Via} {Cap} {Citta} ({Provincia})";
        }
    }
}