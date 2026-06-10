namespace ListaGenerica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lista di oggetti generici!");

            //definizione di una lista di stringhe
            List<object> lista = new List<object>();

            

            lista.Add(12);
            lista.Add(13.50);
            lista.Add(false);
            lista.Add("Mario");

            lista.Insert(2, "Piero");

            Console.WriteLine($"Dimensione: {lista.Count}");

            Console.WriteLine($"Elemento in posizione 3: {lista[3]}");

            Console.WriteLine("Elenco degli elementi della lista");
            foreach (var item in lista)
                Console.WriteLine(item);

            //rimuovere l'elemento in posizione 2
            lista.RemoveAt(2);
            Console.WriteLine("Elemento rimosso in posizione 2");

            Console.WriteLine("Elenco degli elementi della lista");
            foreach (var item in lista)
                Console.WriteLine(item);

            Console.WriteLine("Elenco degli elementi della listadi tipo stringa");
            foreach (var item in lista)
                if (item is string)
                Console.WriteLine(item);
        }
    }
}
