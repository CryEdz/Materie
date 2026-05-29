/*
 * Esercizio - ArrayParalleli

Si considerino il nominativo e l'età di n studenti, memorizzati in due array pre confezionati di pari lunghezza



Si richiede di stampare il nominativo e l'età degli studenti

es.

1 - Carlino Giulia, eta': 29

 2 - Dargen Pietro, eta': 35
 */

Console.WriteLine("Inserisci il numero di studenti: ");
int numeroStudenti = int.Parse(Console.ReadLine());

var eta = new int[numeroStudenti];
var nomi = new string[numeroStudenti];

for (int i = 0; i < nomi.Length; i++)
{
    Console.WriteLine($"Inserisci il nome dello studente {i + 1}: ");
    nomi[i] = Console.ReadLine();
    Console.WriteLine($"Inserisci l'età dello studente {i + 1}: ");
    eta[i] = int.Parse(Console.ReadLine());
}
for (int i = 0; i < nomi.Length; i++)
{
    Console.Write($" --nome: {nomi[i]}, eta: {eta[i]}-- ");
}
