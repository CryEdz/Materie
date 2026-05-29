/*
Dati in input l'imponibile di un costo, 
calcolare il totale da pagare, iva, la ritenuta d'acconto ed il netto a pagare.

Considerare l'aliquota IVA al 22%
Considerare la ritenuta d'acconto pari al 20%

Visualizzare i riultati

es.
imponibile: 1000
Iva 22% su imponibile  = 220
totale lordo = 1220
ritenuta d'acconto 20% su imponibile = 200
totale netto = totale lordo - ritenuta d'acconto = 1020
*/


// definizione costanti
const int ALIQUOTA_IVA = 22;
const int RITENUTA_ACCONTO = 20;

//input
Console.Write("Inserisci l'imponibile da pagare: ");
double imponibile = double.Parse(Console.ReadLine());

//calcoli
double iva = imponibile * ALIQUOTA_IVA / 100;
double totaleLordo = imponibile + iva;
double ritenuta = imponibile * RITENUTA_ACCONTO / 100;
double totaleNetto = totaleLordo - ritenuta;

//output
string msg = $"Totale da pagare: " +
    $"\nimponibile = {imponibile:0.00} euro" +
    $"\niva: ({ALIQUOTA_IVA}% dell'imponibile ) = {iva:0.00} euro" +
    $"\ntotale lordo: {totaleLordo:0.00} euro" +
    $"\nritenuta d'acconto: ({RITENUTA_ACCONTO}% dell'imponibile ) = {ritenuta:0.00} euro" +
    $"\ntotale netto: {totaleNetto:0.00}";

Console.WriteLine(msg);
