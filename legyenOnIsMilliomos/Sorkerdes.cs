using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
    internal class Sorkerdes
    {
        public string Kerdes { get; set; }
        public string[] Valaszok { get; set; }
        public string HelyesSorrend { get; set; }
        public string Tema { get; set; }

        public Sorkerdes()
        {
            Valaszok = new string[4];
        }

        public Sorkerdes(string kerdes, string[] valaszok, string helyesSorrend, string tema)
        {
            Kerdes = kerdes;
            Valaszok = valaszok;
            HelyesSorrend = helyesSorrend;
            Tema = tema;
        }
    }
}
