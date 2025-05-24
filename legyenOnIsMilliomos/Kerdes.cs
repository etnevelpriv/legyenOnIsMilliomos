using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Kerdes
    {
        public int Szint { get; set; }
        public string KerdesSzoveg  { get; set; }
        public List<string> Valasz { get; set; }
        public string HelyesValasz { get; set; }
        public string Kategoria { get; set; }

        public Kerdes()
        {
            Valasz = new List<string>();
        }

        public Kerdes(int szint, string kerdes, List<string> valasz, string helyesValasz, string kategoria)
        {
            Szint = szint;
            KerdesSzoveg = kerdes;
            Valasz = valasz;
            HelyesValasz = helyesValasz;
            Kategoria = kategoria;
        }
    }
}
