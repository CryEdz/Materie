// Program per leggere due numeri reali da input, calcolare la somma e stampare il risultato.
// Nota: l'input deve essere un valore numerico valido (es. 1.23). Se si usano virgole come separatore
// decimale potrebbe essere necessario adattare la cultura o sostituire ',' con '.' prima del parsing.

float n1, n2, somma;

Console.Write("n1: "); // chiede il primo numero all'utente
n1 = float.Parse(Console.ReadLine()); // converte la stringa letta in un float (solleva FormatException se non valido)

Console.Write("n2: "); // chiede il secondo numero all'utente
n2 = float.Parse(Console.ReadLine()); // converte la stringa letta in un float

somma = n1 + n2; // calcola la somma dei due numeri
Console.WriteLine($"Somma: {somma}"); // stampa il risultato con etichetta

