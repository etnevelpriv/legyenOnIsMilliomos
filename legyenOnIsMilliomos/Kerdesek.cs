using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Kerdesek
    {
        public List<Kerdes> OsszesKerdes { get; private set; }

        public Kerdesek()
        {
            OsszesKerdes = new List<Kerdes>();

            foreach (var sor in File.ReadLines("kerdes.txt"))
            {
                var mezok = sor.Split(';');
                var szint = int.Parse(mezok[0]);
                var kerdesSzoveg = mezok[1];
                var valaszok = new List<string> {mezok[2], mezok[3], mezok[4], mezok[5]};
                var helyesValasz = mezok[6];
                var kategoria = mezok[7];
                var kerdes = new Kerdes(szint, kerdesSzoveg, valaszok, helyesValasz, kategoria);
                OsszesKerdes.Add(kerdes);
            }
        }
    }
}

