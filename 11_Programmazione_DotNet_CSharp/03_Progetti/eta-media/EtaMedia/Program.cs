/*Calocare la media aritmetica di n numeri interi strettamente positivi
 visualizzare il risultato
l'inserimento termina quando l'utente inserisce un numero negativo o nullo
*/


int somma = 0;
int conta = 0;
int numero;
do
{
    Console.WriteLine("Inserisci un numero intero positivo");
    numero= int.Parse(Console.ReadLine());

    if (numero > 0)
    {
        somma += numero;
        conta++;
    }
    else Console.WriteLine("Inserimento sequenza terminato");


} while (numero > 0);
if (conta > 0)
{
    double media = (double)somma / conta;
    Console.WriteLine($"media aritmetica ={media}");
}
else Console.WriteLine("Non sono stati inseriti numeri positivi");