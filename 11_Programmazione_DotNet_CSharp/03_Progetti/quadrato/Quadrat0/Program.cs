/*
Dati in input il lato di un quadrato calocalre il perimetro, l'area e la diagonale
visualizzare i risultati 
*/


//input
Console.Write("Inserisci il lato del quadrato: ");
double lato = double.Parse(Console.ReadLine());

//calcoli
double perimetro = lato * 4;
double area = Math.Pow(lato, 2);
double diagonale = lato * Math.Sqrt(2);

//output
string msg = $"Dati del Quadrato: " +
    $"lato={lato}" +
    $", Perimetro: {perimetro}" +
    $", Area: {area}" +
    $", Diagonale: {diagonale}";

Console.WriteLine(msg);
