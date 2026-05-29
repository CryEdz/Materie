/*
 Dai in input il prezzo e la quantità di acquisto di un prodotto,
calcolare il totale da pagare
Visualizzare il risultato
*/

int quantita;
double prezzo, totale;

Console.Write("Inserisci la quantità del prodotto: ");
quantita = int.Parse(Console.ReadLine());

Console.Write("Inserisci prezzo del prodotto: ");
prezzo = double.Parse(Console.ReadLine());

totale = (double)(prezzo * quantita);

Console.Write("Totale da pagare: " + totale:#.## + "euro");

