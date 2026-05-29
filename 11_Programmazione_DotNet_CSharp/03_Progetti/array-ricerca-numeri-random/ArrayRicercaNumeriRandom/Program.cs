/*
 * Generare un array di n numeri casuali, appartenenti ad un intervallo [inf, sup]
 * con n, inf e sup inseriti dall'utente.
 * effettuare la ricerca di un numero dato in input e visualizzare la prima occorrenza utile
 * trovata in una cerca posizione 
 * oppure visualizzzare numero non trovato
 * 
 */

int n;
int inf;
int sup;

Console.Write("Inserisci il numero di elementi dell'array: ");
n= int.Parse(Console.ReadLine());

Console.Write("Inserisci il limite inferiore dell'intervallo: ");
inf = int.Parse(Console.ReadLine());

Console.Write("Inserisci il limite superiore dell'intervallo: ");
sup = int.Parse(Console.ReadLine());

int[] numeri = new int[n];

for (int i= 0; i < n; i++)
{
    Random random = new Random();
    numeri[i] = random.Next(inf,sup);

}

//ricerca

int ricerca;
Console.Write("Inserisci il numero da ricercare: ");
ricerca = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    if (numeri[i] == ricerca)
    {
        Console.WriteLine($"Il numero {ricerca} è stato trovato alla posizione {i + 1}");
        i = n;
    }
}
if (ricerca != numeri[n - 1]){
    Console.WriteLine("Numero non trovato");
};