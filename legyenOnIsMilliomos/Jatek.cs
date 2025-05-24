using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Jatek
    {
        public void Indit()
        {
            var sorkerdesek = new Sorkerdesek();
            var random = new Random();
            while (true)
            {
                var r = random.Next(sorkerdesek.OsszesSorKerdes.Count);
                var kerdes = sorkerdesek.OsszesSorKerdes[r];

                Console.Clear();
                Console.Write("Téma: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(kerdes.Tema);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(kerdes.Kerdes);

                Console.ForegroundColor = ConsoleColor.Blue;
                char[] betuk = { 'A', 'B', 'C', 'D' };
                for (int i = 0; i < kerdes.Valaszok.Length; i++)
                {
                    Console.WriteLine($"{betuk[i]}) {kerdes.Valaszok[i]}");
                }

                var start = DateTime.Now;

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Válasz (pl: CDAB): ");
                string valasz = Console.ReadLine()?.Trim().ToUpper() ?? "";

                var eltelt = DateTime.Now - start;

                if (valasz == kerdes.HelyesSorrend.ToUpper() && eltelt.TotalSeconds <= 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Helyes válasz! ({eltelt.TotalSeconds:0.00} másodperc)");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A válaszod hibás, vagy pedig túl lassú voltál. Próbáld újra egy új kérdéssel.");
                    Console.WriteLine($"Válaszod: {valasz}");
                    Console.WriteLine($"Eltelt idő: {eltelt.TotalSeconds:0.00} másodperc");
                    Console.WriteLine($"Helyes válasz: {kerdes.HelyesSorrend}");
                    Console.ResetColor();
                    Console.Write("Szeretnéd újrapróbálni? (i/n): ");
                    string ujra = Console.ReadLine().ToLower();
                    if (ujra != "i")
                    {
                        break;
                    }
                }
            }
        }
    }
}
