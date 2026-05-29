using System;

namespace HardDisk
{
    internal class ClasseHardDisk
    {
        public string Marca { get; }
        public int RTM { get; }
        public int TempoDiAccesso { get; }
        public int Capacita { get; }

        public ClasseHardDisk(string marca, int rtm, int tempoDiAccesso, int capacita)
        {
            Marca = marca;
            RTM = rtm;
            TempoDiAccesso = tempoDiAccesso;
            Capacita = capacita;
        }

        public int CalcolaPunteggio()
        {
            return RTM - (TempoDiAccesso * 200) + (Capacita * 500);
        }

        public override string ToString()
        {
            return $"Marca: {Marca}, RTM: {RTM}, Tempo accesso: {TempoDiAccesso} ms, Capacità: {Capacita} GB, Punteggio: {CalcolaPunteggio()}";
        }
    }
}
