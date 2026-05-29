/*
Dati in input l'imponibile di un costo, 
calcolare la rivalsa, l'imponibile, il totale da pagare, iva, la ritenuta d'acconto ed il netto a pagare.

Considerare l'aliquota IVA al 22%
Considerare la ritenuta d'acconto pari al 20%
Considerare la rivalsa al 4%

Visualizzare i riultati

es.
costo:1000 

costo = 1000
rivalsa 4% del costo = 40
imponibile = 1040
Iva 22% su imponibile  = 220
totale lordo = 1220
ritenuta d'acconto 20% su imponibile = 200
totale netto = totale lordo - ritenuta d'acconto = 1020
*/


// definizione costanti
const int ALIQUOTA_IVA = 22;
const int RITENUTA_ACCONTO = 20;
const int RIVALSA = 4;
//input
Console.Write("Inserisci il costo: ");
double costo = double.Parse(Console.ReadLine());

//calcoli
double rivalsa = costo * RIVALSA / 100;
double imponibile = costo + rivalsa;
double iva = imponibile * ALIQUOTA_IVA / 100;
double totaleLordo = imponibile + iva;
double ritenuta = imponibile * RITENUTA_ACCONTO / 100;
double totaleNetto = totaleLordo - ritenuta;

//output
string msg = $"Totale da pagare: " +
    $"\ncosto = {costo:0.00} euro" +
    $"\nrivalsa: ({RIVALSA}% del costo ) = {rivalsa:0.00} euro" +
    $"\nimponibile = {imponibile:0.00} euro" +
    $"\niva: ({ALIQUOTA_IVA}% dell'imponibile ) = {iva:0.00} euro" +
    $"\ntotale lordo: {totaleLordo:0.00} euro" +
    $"\nritenuta d'acconto: ({RITENUTA_ACCONTO}% dell'imponibile ) = {ritenuta:0.00} euro" +
    $"\ntotale netto: {totaleNetto:0.00}euro ";

Console.WriteLine(msg);
