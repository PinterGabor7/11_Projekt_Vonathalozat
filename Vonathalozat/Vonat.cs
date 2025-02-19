using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonathalozat
{
    public class Vonat
    {
        public string jaratszam {  get; set; }
        public int ures_helyek {  get; set; }
        public int utasok { get; set; }
        public Allomas KovetkezoAllomas { get; set; }
        public Allomas JelenlegiAllomas { get; set; }
        public Allomas ElozoAllomas { get; set; }
        public int erkezes { get; set; }
        public Vonat(string jaratszam, int ures_helyek = 0, int utasok = 0)
        {
            this.jaratszam = jaratszam;
            this.ures_helyek = ures_helyek;
            this.utasok = utasok;
        }
    }
}
