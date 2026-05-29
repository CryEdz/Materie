
//dati in input: dividento e divisore,
//calcolare il quozioente intero, il resto ed il quozioente reale 
//visualizzare il risultato 

//dichiaro variabili

int dividendo, divisore, qi, r;
double qr; //quozioente reale 

//input
Console.Write("Dividendo:");
dividendo = int.Parse(Console.ReadLine());


Console.Write("Divisore:");
divisore = int.Parse(Console.ReadLine());

//calcolo

qi = dividendo / divisore;
r = dividendo % divisore;
qr = (double)dividendo / divisore;

string msg = $"" +
    $"\nQuoziente intero ={qi}" +
    $"\nResto = {r}" +
    $"\nQuoziente reale {qr}";

Console.WriteLine(msg);