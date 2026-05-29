Console.WriteLine("Generazione di un numero casuale!");


Random random = new Random();//sintassi per allocare l'istanza di un oggetto 

int casuale = random.Next(1 ,90);//sintassi per invocare un metodo di un oggetto

Console.WriteLine(casuale);