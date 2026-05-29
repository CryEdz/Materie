/*
Dati in input il prezzo e la quantità e la percentuale di sconto di acquisto di un prodotto,
calcolare il totale da pagare
Visualizzare il risultato, il totale , lo sconto e il totale scontato.
es.
prezzzo: 10.00
quantità: 3
percentuale sconto: 30%

totale = 30,00 euro
sconto = 9,00 euro
totale scontato = 21,00 euro
*/

int quantita;
double prezzo, totale, sconto, totaleScontato;

Console.Write("Inserisci la quantità del prodotto: ");
quantita = int.Parse(Console.ReadLine());

Console.Write("Inserisci prezzo del prodotto: ");
prezzo = double.Parse(Console.ReadLine());

Console.Write("Inserisci la percentuale di sconto: ");
sconto = double.Parse(Console.ReadLine());

totale =(prezzo * quantita);
double totsconto =(totale*(sconto/100));
totaleScontato =(totale-totsconto);

Console.Write(
    $"Totale: {totale:0.00 euro}\n" +
    $"Sconto applicato: {totsconto:0.00 euro}\n" +
    $"Totale scontato: {totaleScontato:0.00 euro}");


