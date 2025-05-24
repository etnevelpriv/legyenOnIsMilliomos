namespace legyenOnIsMilliomos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kerdesek = new Kerdesek();

            foreach (var kerdes in kerdesek.OsszesKerdes.Take(10))
            {
                Console.WriteLine(kerdes.KerdesSzoveg);
            }
        }
    }
}
