/*
Dati in input il raggio di un cerchio calocalre il diametro, l'area e la circonferenza
visualizzare i risultati 
*/


//input
Console.Write("Inserisci il raggio del cerchio: ");
double raggio = double.Parse(Console.ReadLine());

//calcoli
double diametro = raggio * 4;
double area = Math.PI*Math.Pow(raggio, 2);
double circonferenza = diametro * Math.PI;

//output
string msg = $"Dati del Cerchio: " +
    $"raggio={raggio}" +
    $", Diametro: {diametro}" +
    $", Area: {area}" +
    $", Circonferenza: {circonferenza}";

Console.WriteLine(msg);
