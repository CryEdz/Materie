
//Dato in input un numero intero
//verificare se è pari o dispari
//Visualizzare il risultato

//es. input => 5 
//output => "5 è un numero dispari"



Console.WriteLine("Pari o Dispari!");

Console.Write("Inserisci un numero intero: ");
int n = int.Parse(Console.ReadLine());

int resto = n % 2;

if  (resto == 0) 
{
    Console.WriteLine($"{n} è un numero pari");
}
else
{
    Console.WriteLine($"{n} è un numero dispari");
}