using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Sorkerdesek
    {
        public List<Sorkerdes> OsszesSorKerdes { get; private set; }

        public Sorkerdesek()
        {
            OsszesSorKerdes = new List<Sorkerdes>();

            foreach (var sor in File.ReadLines("sorkerdes.txt"))
            {
                var mezok = sor.Split(';');
                var kerdes = mezok[0];
                var valaszok = new string[] {mezok[1], mezok[2], mezok[3], mezok[4]};
                var helyesValasz = mezok[5];
                var kategoria = mezok[6];
                var sorkerdes = new Sorkerdes(kerdes, valaszok, helyesValasz, kategoria);
                OsszesSorKerdes.Add(sorkerdes);
            }
        }
    }
}
