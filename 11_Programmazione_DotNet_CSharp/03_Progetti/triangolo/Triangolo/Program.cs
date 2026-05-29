/*
 Dati in input i dati di un triangolo
calcolare il perimetro, l'area e il tipo di triangolo
visualizzare i risultati ottenuti

 */

Console.WriteLine("Triangolo!");

//input
Console.Write("Lato1: ");
double lato1 = double.Parse(Console.ReadLine());

Console.Write("Lato2: ");
double lato2 = double.Parse(Console.ReadLine());

Console.Write("Lato3: ");
double lato3 = double.Parse(Console.ReadLine());

//sanitizzazione
bool isCostruibile = (lato1 + lato2 > lato3) && (lato1 + lato3 > lato2) && (lato2 + lato3 > lato1);

if (isCostruibile)
{
    //calcoli
    double perimetro = lato1 + lato2 + lato3;

    //area = formula di Erone
    double semiperimetro = perimetro / 2;
    double area = Math.Sqrt(semiperimetro * (semiperimetro - lato1) * (semiperimetro - lato2) * (semiperimetro - lato3));

    string tipo = "Scaleno";
    if (lato1 == lato2 && lato2 == lato3)
    {
        tipo = "Equilatero";
    }
    else if (lato1 == lato2 || lato2 == lato3 || lato1 == lato3)
    {
        tipo = "Isoscele";
    }

    //output
    //forma dettaglio
    string msg = $"" +
        $"lato 1={lato1}" +
        $"\nlato 2={lato2}" +
        $"\nlato 3={lato3}" +
        $"\nPerimetro: {perimetro}" +
        $"\nArea: {area}" +
        $"\nTipo: {tipo}";


    Console.WriteLine(msg);
}
else
    Console.WriteLine("Con i dati inseriti non si può costruire un triangolo");
