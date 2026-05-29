//commento in linea
/*Commento
    in 
    blocco
 */

// testo: dati in input due numeri interi,
//calcolare la somma 
// visualizzare il risultato

//dichiarazione di variabili
int n1, n2, somma;
string tmp;

//input
Console.Write("n1: ");
tmp = Console.ReadLine(); //"4"
n1 = int.Parse(tmp); // "4" => 4


Console.Write("n2: ");
tmp = Console.ReadLine();
n2  = int.Parse(tmp);

//calcolo

somma = n1 + n2;

//output

Console.WriteLine(somma);
Console.WriteLine("Somma = " + somma); //stile java
Console.WriteLine("Somma={0}", somma); //Segnaposto stile C#
Console.WriteLine(n1 + "+" + n2 + "=" + somma); //stile java 
Console.WriteLine("{0}+{1}={2}", n1, n2, somma);
Console.WriteLine($"{n1}+{n2}+{somma}"); //interpolazione 
