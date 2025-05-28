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
            bool helyesSorkerdes = false;
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

                if (valasz == kerdes.HelyesSorrend.ToUpper() && eltelt.TotalSeconds <= 300)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Helyes válasz! ({eltelt.TotalSeconds:0.00} másodperc)");
                    Console.ResetColor();
                    helyesSorkerdes = true;
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
                        return;
                    }
                }
            }

            if (helyesSorkerdes)
            {
                var kerdesek = new Kerdesek();
                int[] nyeremenyek = {
                        10000, 50000, 100000, 250000, 500000,
                        1000000, 2500000, 5000000, 10000000, 15000000,
                        20000000, 25000000, 30000000, 40000000, 50000000
                    };
                int szint = 1;
                int nyertOsszeg = 0;

                for (int i = 0; i < 15; i++)
                {
                    List<Kerdes> szintKerdesek = new List<Kerdes>();
                    foreach (Kerdes k in kerdesek.OsszesKerdes)
                    {
                        if (k.Szint == szint)
                        {
                            szintKerdesek.Add(k);
                        }
                    }

                    var kerdes = szintKerdesek[random.Next(szintKerdesek.Count)];

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n{szint}. kérdés - {nyeremenyek[i]} Ft");
                    Console.ResetColor();
                    Console.Write("Téma: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(kerdes.Kategoria);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(kerdes.KerdesSzoveg);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    char[] betuk = { 'A', 'B', 'C', 'D' };
                    for (int j = 0; j < kerdes.Valasz.Count; j++)
                    {
                        Console.WriteLine($"{betuk[j]}) {kerdes.Valasz[j]}");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Válasz (Pl: A): ");
                    string valasz = Console.ReadLine()?.Trim().ToUpper() ?? "";

                    if (valasz == kerdes.HelyesValasz.ToUpper())
                    {
                        nyertOsszeg = nyeremenyek[i];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Helyes válasz!");
                        Console.ResetColor();

                        if (szint == 15)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Gratulálok! Megnyerted a fődíjat: {nyertOsszeg} Ft!");
                            Console.ResetColor();
                            break;
                        }

                        Console.Write("Szeretnéd folytatni a játékot? (i/n): ");
                        string folytat = Console.ReadLine().ToLower();
                        if (folytat != "i")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Nyert összeged: {nyertOsszeg} Ft");
                            Console.ResetColor();
                            break;
                        }
                        szint++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rossz válasz!");
                        Console.WriteLine($"A helyes válasz ez lett volna: {kerdes.HelyesValasz}");
                        Console.ResetColor();

                        if (szint > 10)
                        {
                            nyertOsszeg = nyeremenyek[9];
                        }
                        else if (szint > 5)
                        {
                            nyertOsszeg = nyeremenyek[4];
                        }
                        else
                        {
                            nyertOsszeg = 0;
                        }

                        if (nyertOsszeg > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Biztos nyereményed: {nyertOsszeg} Ft");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sajnos nem nyertél semmit.");
                            Console.ResetColor();
                        }
                        break;
                    }
                }
            }
        }
    }
}
