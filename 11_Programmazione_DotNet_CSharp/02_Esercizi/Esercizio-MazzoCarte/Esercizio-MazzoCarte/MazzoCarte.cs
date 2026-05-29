namespace Esercizio_MazzoCarte
{
    internal class MazzoCarte
    {
        private List<Carta> carte;
        private Random random = new Random();

        public MazzoCarte()
        {
            carte = new List<Carta>();
            InizializzaMazzo();
        }

        private void InizializzaMazzo()
        {
            // Crea 40 carte ordinate: per ogni seme, tutti i valori da Asso a Re
            foreach (Carta.Semi seme in Enum.GetValues(typeof(Carta.Semi)))
            {
                foreach (Carta.Valore valore in Enum.GetValues(typeof(Carta.Valore)))
                {
                    carte.Add(new Carta(seme, valore));
                }
            }
        }

        public void Mescola(int numMescolamenti = 300)
        {
            for (int i = 0; i < numMescolamenti; i++)
            {
                // Algoritmo Fisher-Yates shuffle
                int n = carte.Count;
                for (int j = n - 1; j > 0; j--)
                {
                    int k = random.Next(j + 1);
                    // Scambia carte[j] con carte[k]
                    (carte[j], carte[k]) = (carte[k], carte[j]);
                }
            }
        }

        public void Stampa()
        {
            Console.WriteLine("=== MAZZO DI CARTE ===\n");
            for (int i = 0; i < carte.Count; i++)
            {
                Console.WriteLine($"{i + 1,2}. {carte[i]}");
            }
            Console.WriteLine($"\nTotale carte: {carte.Count}");
        }
    }
}
