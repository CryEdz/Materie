Console.WriteLine("Array di nomi di persone!");

//array di nomi di persone



string[] nomi = new string[]
{
    // 100 nomi femminili
    "Sofia", "Giulia", "Aurora", "Alice", "Ginevra", "Emma", "Giorgia", "Martina", "Beatrice", "Anna",
    "Francesca", "Chiara", "Alessia", "Greta", "Matilde", "Sara", "Nicole", "Elisa", "Bianca", "Camilla",
    "Noemi", "Arianna", "Ludovica", "Federica", "Valentina", "Veronica", "Ilaria", "Elena", "Miriam", "Caterina",
    "Agnese", "Gaia", "Melissa", "Silvia", "Paola", "Carla", "Laura", "Roberta", "Barbara", "Monica",
    "Daniela", "Simona", "Stefania", "Patrizia", "Antonella", "Claudia", "Debora", "Donatella", "Eleonora", "Flavia",
    "Gabriella", "Irene", "Jessica", "Katia", "Linda", "Manuela", "Nadia", "Olivia", "Pamela", "Rachele",
    "Sabrina", "Tatiana", "Ursula", "Viola", "Wanda", "Ylenia", "Zara", "Marika", "Romina", "Serena",
    "Teresa", "Umberta", "Viviana", "Zoe", "Alessandra", "Benedetta", "Carlotta", "Diana", "Emanuela", "Fabiola",
    "Gemma", "Helga", "Isabella", "Joelle", "Karen", "Livia", "Michela", "Norma", "Oriana", "Priscilla",
    "Rebecca", "Samanta", "Tiziana", "Valeria", "Wilma", "Xenia", "Yara", "Zaira", "Rosaria", "Lucia",

    // 100 nomi maschili
    "Leonardo", "Francesco", "Alessandro", "Lorenzo", "Mattia", "Andrea", "Gabriele", "Tommaso", "Riccardo", "Edoardo",
    "Giuseppe", "Marco", "Davide", "Simone", "Luca", "Matteo", "Antonio", "Christian", "Samuele", "Nicolo",
    "Federico", "Emanuele", "Filippo", "Jacopo", "Diego", "Michele", "Pietro", "Salvatore", "Vincenzo", "Roberto",
    "Claudio", "Stefano", "Paolo", "Massimo", "Carlo", "Daniele", "Enrico", "Fabio", "Giorgio", "Ivan",
    "Karim", "Luigi", "Manuel", "Nando", "Omar", "Pasquale", "Raffaele", "Sergio", "Tiziano", "Ugo",
    "Valerio", "Walter", "Xavier", "Yuri", "Zeno", "Alberto", "Bruno", "Cesare", "Dario", "Elia",
    "Fabrizio", "Giacomo", "Hugo", "Ignazio", "Jonathan", "Kevin", "Leandro", "Moreno", "Nicola", "Orlando",
    "Primo", "Quintino", "Renato", "Tristano", "Teodoro", "Ulisse", "Vittorio", "William", "Youssef", "Zaccaria",
    "Amedeo", "Benito", "Corrado", "Domenico", "Ernesto", "Flavio", "Gerardo", "Horacio", "Ismaele", "Joel",
    "Khaled", "Livio", "Mariano", "Nereo", "Osvaldo", "Piero", "Quirino", "Ruggero", "Silvano", "Umberto"
};

foreach (string nome in nomi)
  Console.WriteLine(nome);