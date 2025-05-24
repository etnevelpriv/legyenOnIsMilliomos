using System;
using System.Collections.Generic;
using System.IO;

namespace legyenOnIsMilliomos
{
    internal class Kerdesek
    {
        public List<Kerdes> OsszesKerdes { get; private set; }
        public Dictionary<int, List<Kerdes>> Szintenkent { get; private set; }

        public Kerdesek(string fajlNev = "kerdes.txt")
        {
            OsszesKerdes = new List<Kerdes>();
            Szintenkent = new Dictionary<int, List<Kerdes>>();

            if (!File.Exists(fajlNev))
                throw new FileNotFoundException($"A(z) {fajlNev} fájl nem található.");

            foreach (var sor in File.ReadLines(fajlNev))
            {
                if (string.IsNullOrWhiteSpace(sor)) continue;

                var mezok = sor.Split(';');
                if (mezok.Length < 8) continue; // Hibás sor

                if (!int.TryParse(mezok[0], out int szint)) continue;

                var kerdesSzoveg = mezok[1];
                var valaszok = new List<string> { mezok[2], mezok[3], mezok[4], mezok[5] };
                var helyesValasz = mezok[6].Length > 0 ? mezok[6][0] : ' ';
                var kategoria = mezok[7];

                var kerdes = new Kerdes(kerdesSzoveg, valaszok, helyesValasz, kategoria);
                OsszesKerdes.Add(kerdes);

                if (!Szintenkent.ContainsKey(szint))
                    Szintenkent[szint] = new List<Kerdes>();
                Szintenkent[szint].Add(kerdes);
            }
        }
    }
}
