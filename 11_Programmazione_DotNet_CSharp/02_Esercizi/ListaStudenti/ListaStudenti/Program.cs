namespace ListaStudenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lista di ogetti di tipo Studente!");

            List<Studente> elenco = new List<Studente>() {
    new Studente(){Matricola=12346,Nome="Diego", Cognome="De Lillo", Email="diego.delillo@its.net", Classe="Mobile Developer"},
    new Studente(){Matricola=12356,Nome="Marta", Cognome="De Paoli", Email="marta.depaoli@its.net", Classe="Mobile Developer"},
    new Studente(){Matricola=12126,Nome="Carlo", Cognome="De Carlo", Email="carlo.decarlo@its.net", Classe="Mobile Developer"},
    new Studente(){Matricola=12345,Nome="Pietro", Cognome="De Lillo", Email="pietro.delillo@its.net", Classe="Cloud Specialist"},
    new Studente(){Matricola=12350,Nome="Laura", Cognome="De Paoli", Email="laura.depaoli@its.net", Classe="Backend Developer"},
    new Studente(){Matricola=12121,Nome="Giulia", Cognome="De Carlo", Email="giulia.decarlo@its.net", Classe="Cloud Specialist"},
    new Studente(){Matricola=11123,Nome="Roberto", Cognome="Di Freud", Email="roberto.difreud@its.net", Classe="Backend Developer"},
    new Studente(){Matricola=10256,Nome="Andrea", Cognome="Di Leo", Email="andrea.dileo@its.net", Classe="Cloud Specialist"},
    new Studente(){Matricola=11345,Nome="Laura", Cognome="De Laurentis", Email="laura.delaurentis@its.net", Classe="Backend Developer"},
    new Studente(){Matricola=11350,Nome="Laura", Cognome="De Giovanni", Email="laura.degiovanni@its.net", Classe="Cloud Specialist"},
    new Studente(){Matricola=10121,Nome="Roberto", Cognome="Vigna", Email="roberto.vigna@its.net", Classe="Cloud Specialist"},
    new Studente(){Matricola=13123,Nome="Roberto", Cognome="Di Pinto", Email="roberto.dipinto@its.net", Classe="Backend Developer"},
    new Studente(){Matricola=11256,Nome="Andrea", Cognome="Scotto", Email="andrea.scotto@its.net", Classe="Cloud Specialist"}
};

            string menu = "Scegli una tra le seguenti opzioni:" +
                "\n1- Visualizzare l'elenco degli studenti" +
                "\n2- Visualizzare la scheda dettaglio di uno studente, di cui si conosce la matricola. La matricola è fornita da input." +
                "\n3- Visualizzare l'elenco degli studenti che hanno il cognome in comune. Il cognome è dato da input" +
                "\n4- Visualizzare gli studenti appartenenti ad una certa classe. La classe è data da input" +
                "\n0- Termina il programma" +
                "\n\nScelta: ";

            int scelta;
            do
            {
                Console.Write(menu);
                scelta = int.Parse(Console.ReadLine());

            switch (scelta)
                {
                    case 0: Console.WriteLine("Programma terminato!"); break;
                    case 1: Console.WriteLine(string.Join("\n", elenco)); break;
                    case 2:
                        {
                            Console.Write("Matricola: ");
                            int m = int.Parse(Console.ReadLine());
                            foreach (var item in elenco)
                                if (item.Matricola == m)
                                    Console.WriteLine(item.FormatStampaDettaglio());
                        } break;
                    case 3:
                        { 
                            Console.Write("\nCognome: ");
                            string cognome = Console.ReadLine();
                            foreach (var item in elenco)
                                if (item.Cognome.Equals(cognome))
                                    Console.WriteLine($"{item.FormatStampaLineare()}");
                        } break;
                    case 4:
                        {
                            Console.Write("\nClasse: ");
                            string classe = Console.ReadLine();
                            foreach (var item in elenco)
                                if (item.Classe.Equals(classe))
                                    Console.WriteLine($"{item.FormatStampaLineare()}");
                        }
                        break;
                    default: Console.WriteLine("Errore! Dato inserito non valido!"); break;


                }
            } while (scelta != 0);
        }
    }
}
