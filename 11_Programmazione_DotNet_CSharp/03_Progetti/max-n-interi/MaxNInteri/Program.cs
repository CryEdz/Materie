/*
 * dato in input N numeri interi, restituire il massimo tra di essi
 * Visualizzare il risultato
 */



Console.WriteLine("Hello, World!");

Console.Write("Quanti numeri vuoi inserire?");
int n= int.Parse(Console.ReadLine());

int numero = 0;
int max = int.MinValue;

for (int i = 0; i < n; i++)
{
    Console.Write("Inserisci un numero intero: ");
    numero = int.Parse(Console.ReadLine());
    if (numero > max)
    {
        
        max = numero;
    }
Console.WriteLine("Il numero massimo è: " + max);
}
