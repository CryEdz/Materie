namespace Polimorfismo
{
    /// <summary>
    /// Classe che rappresenta un dipendente amministrativo.
    /// Estende la classe Dipendente e aggiunge il concetto di mansione.
    /// Lo stipendio include un bonus specifico in base alla mansione svolta.
    /// </summary>
    internal class Amministrativo : Dipendente
    {
        /// <summary>
        /// Mansione del dipendente amministrativo
        /// </summary>
        public Mansione Mansione { get; set; }

        /// <summary>
        /// Costruttore della classe Amministrativo.
        /// </summary>
        /// <param name="cognome">Cognome del dipendente</param>
        /// <param name="nome">Nome del dipendente</param>
        /// <param name="pagaOraria">Paga oraria in euro</param>
        /// <param name="oreLavorate">Numero di ore lavorate</param>
        /// <param name="mansione">Mansione svolta dal dipendente</param>
        public Amministrativo(string cognome, string nome, decimal pagaOraria, decimal oreLavorate, Mansione mansione)
            : base(cognome, nome, pagaOraria, oreLavorate)
        {
            Mansione = mansione;
        }

        /// <summary>
        /// Calcola lo stipendio dell'amministrativo aggiungendo il bonus
        /// relativo alla mansione svolta (Contabile +150€, Risorse Umane +75€, Direttore +250€).
        /// </summary>
        /// <returns>Lo stipendio lordo incluso il bonus di mansione</returns>
        public override decimal CalcolaStipendio()
        {
            decimal stipendioBase = base.CalcolaStipendio();
            return Mansione switch
            {
                Mansione.Contabile => stipendioBase + 150,
                Mansione.RisoreUmane => stipendioBase + 75,
                Mansione.Direttore => stipendioBase + 250,
                _ => stipendioBase
            };
        }

        /// <summary>
        /// Visualizza le informazioni dell'amministrativo includendo
        /// le informazioni base e la mansione specifica.
        /// </summary>
        public override void Visualizza()
        {
            base.Visualizza();
            Console.WriteLine($"Categoria: Amministrativo");
            Console.WriteLine($"Mansione: {Mansione}");
            Console.WriteLine();
        }
    }
}
