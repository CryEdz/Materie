Console.WriteLine("Lacio del dado!");
for (int i = 0; i < 1;)
{
    Console.WriteLine("\nLacio del dado!");
    Console.ReadLine();

    Random random = new Random();
    int dado = random.Next(6)+1;
    Console.WriteLine(dado);
}