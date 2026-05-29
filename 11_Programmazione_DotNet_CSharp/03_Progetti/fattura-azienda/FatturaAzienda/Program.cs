/*
Dati in input l'imponibile di un costo, 
calcolare il totale da pagare

Considerare l'aliquota IVA al 22%

Visualizzare i riultati

es.
imponibile: 1000
Iva 22% su imponibile  = 220
totale da pagare = 1220




*/


//input
Console.Write("Inserisci l'imponibile da pagare: ");
double imponibile = double.Parse(Console.ReadLine());

const int ALIQUOTA_IVA = 22;

//calcoli
double iva = imponibile * ALIQUOTA_IVA / 100;
double totale = imponibile + iva;

//output
string msg = $"Totale da pagare: " +
    $"\nimponibile = {imponibile:0.00} euro" +
    $"\niva: ({ALIQUOTA_IVA}% dell'imponibile ) = {iva:0.00} euro" +
    $"\ntotale: {totale:0.00} euro";

Console.WriteLine(msg);
