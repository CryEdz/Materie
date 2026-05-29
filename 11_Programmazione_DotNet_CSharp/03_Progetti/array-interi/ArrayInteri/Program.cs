Console.WriteLine("Array di numeri interi!");

//definizione di un Array
//Tipo[] identificatore = istanza con dimensione

int[] numeri = new int[5];

//scrittura 

numeri[0] = 12;
numeri[1] = 1;
numeri[2] = 2;
numeri[3] = 3;
numeri[4] = 4;

//lettura

Console.WriteLine($"Posizione 3: {numeri[3]}");

for ( int i = 0; i < numeri.Length; i++)
{
    Console.WriteLine($"Posizione {i}: {numeri[i]}");
}

foreach (int x in numeri)
Console.WriteLine( x );

