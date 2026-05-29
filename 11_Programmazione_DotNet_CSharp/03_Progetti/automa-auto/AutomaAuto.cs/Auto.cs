namespace AutomaAuto.cs
{
    internal class Auto
    {
        public int VelocitaAttuale { get; private set; }

        public Auto(int velocitaIniziale)
        {
            VelocitaAttuale = velocitaIniziale;
        }

        public void Accelera()
        {
            VelocitaAttuale += 10;
        }

        public void Frena()
        {
            VelocitaAttuale -= 5;
        }
    }
}
