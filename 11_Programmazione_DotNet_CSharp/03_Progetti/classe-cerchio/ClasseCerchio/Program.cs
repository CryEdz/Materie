namespace ClasseCerchio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanza di cerchio!");

            Cerchio c1 = new Cerchio(); //istanza
            c1.SetRaggio(0.5);

            Console.WriteLine($"Il raggio del cerchio è: {c1.GetRaggio()}");
            Console.WriteLine($"La circonferenza del cerchio è: {c1.Circonferenza()}");
            Console.WriteLine($"Il diametro del cerchio è: {c1.Diametro()}");
            Console.WriteLine($"L'area del cerchio è: {c1.Area()}");
        }
    }
}
