using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Kerdes
    {
        public string Kerdes { get; set; }
        public List<string> Valasz { get; set; }
        public char HelyesValasz { get; set; }
        public string Kategoria { get; set; }

        public Kerdes()
        {
            Valasz = new List<string>();
        }

        public Kerdes(string kerdes, List<string> valasz, char helyesValasz, string kategoria)
        {
            Kerdes = kerdes;
            Valasz = valasz;
            HelyesValasz = helyesValasz;
            Kategoria = kategoria;
        }
    }
}
