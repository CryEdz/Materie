//simulare l'uscita di un lotto con 5 numeri casuali tra 1 e 90

int e1, e2, e3, e4, e5;

Console.Write("Simulazione uscita lotto");

Random random = new Random();

e1 =new Random().Next(90)+1;

do{
    e2 = new Random().Next(90)+1;
}while (e2 == e1);

do {
    e3 = new Random().Next(90)+1;
} while (e3 == e1 || e3 == e2); 

do {
    e4 = new Random().Next(90)+1;
} while (e4 == e1 || e4 == e2 || e4 == e3);

do {
    e5 = new Random().Next(90)+1;
} while (e5 == e1 || e5 == e2 || e5 == e3 || e5 == e4);

Console.WriteLine($"I numeri estratti sono: {e1}, {e2}, {e3}, {e4}, {e5}");

